using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading;
using Aquarius.Helpers;
using Aquarius.TimeSeries.Client.NativeTypes;
using ServiceStack;

namespace Aquarius.TimeSeries.Client
{
    public static class ServiceClientExtensions
    {
        public static TPollResponse RequestAndPollUntilComplete<TAsyncResponse, TPollResponse>(
            this IServiceClient client,
            Func<IServiceClient, TAsyncResponse> requestFunc,
            Func<IServiceClient, TAsyncResponse, TPollResponse> pollFunc,
            Func<TPollResponse, bool> pollResponseCompletedFunc,
            CancellationToken? cancellationToken = null,
            TimeSpan? maximumElapsedTimeSpan = null)
        {
            var asyncResponse = requestFunc(client);

            var pollingTimer = new AdaptivePollingTimer(maximumElapsedTimeSpan, cancellationToken);

            while (true)
            {
                pollingTimer.ThrowIfMaximumElapsedTimeSpanExceeded();

                var pollResponse = pollFunc(client, asyncResponse);

                if (pollResponseCompletedFunc(pollResponse))
                    return pollResponse;

                pollingTimer.WaitOnePollingInterval();
            }
        }

        private static readonly ConcurrentDictionary<IServiceClient, ServerRequestNameResolver>
            EndpointRequestNameResolvers = new ConcurrentDictionary<IServiceClient, ServerRequestNameResolver>();

        public static IEnumerable<TResponse> SendAll<TRequest, TResponse>(
            this IServiceClient client,
            int batchSize,
            IEnumerable<TRequest> requests,
            Action<TRequest, ResponseStatus> failedRequestHandler = null,
            CancellationToken? cancellationToken = null,
            IProgressReporter progressReporter = null)
            where TRequest : IReturn<TResponse>
        {
            var responses = new List<TResponse>();

            progressReporter?.Started();

            var requestBatches = BatchesOf(requests, batchSize)
                .ToList();

            var totalCount = requestBatches.Sum(b => b.Length);

            var failedRequests = 0;

            foreach (var requestBatch in requestBatches)
            {
                var firstRequest = requestBatch.First();

                var requestNameResolver = EndpointRequestNameResolvers
                    .GetOrAdd(client, serviceClient => new ServerRequestNameResolver());

                var serverRequestName = requestNameResolver.ResolveRequestName(client, firstRequest);

                var batchRequests = requestBatch.ToList();

                while (true)
                {
                    if (cancellationToken.HasValue && cancellationToken.Value.IsCancellationRequested)
                        break;

                    try
                    {
                        var batchResponses = SendBatch<TResponse>(client, serverRequestName, batchRequests.Cast<object>());

                        responses.AddRange(batchResponses);

                        break;
                    }
                    catch (WebServiceException webServiceException)
                    {
                        if (failedRequestHandler != null
                            && (webServiceException.ResponseStatus?.Meta?.TryGetValue("AutoBatchIndex", out var textValue) ?? false)
                            && int.TryParse(textValue, out var batchIndex)
                            && batchIndex >= 0 && batchIndex < requestBatch.Length)
                        {
                            failedRequestHandler(batchRequests[batchIndex], webServiceException.ResponseStatus);

                            ++failedRequests;

                            batchRequests.RemoveAt(batchIndex);

                            if (!batchRequests.Any())
                                break;

                            if (failedRequests > totalCount / 4)
                                throw new WebServiceException($"Too many failed batch requests ({failedRequests} out of {totalCount}) for {serverRequestName}.", webServiceException)
                                {
                                    StatusCode = 500
                                };

                            continue;
                        }
 
                        throw;
                    }
                }

                progressReporter?.Progress(responses.Count, totalCount);

                if (cancellationToken.HasValue && cancellationToken.Value.IsCancellationRequested)
                    break;
            }

            progressReporter?.Completed();

            return responses;
        }

        private static List<TResponse> SendBatch<TResponse>(IServiceClient client, string requestName, IEnumerable<object> requests)
        {
            // Monkey-patched from ServiceStack\src\ServiceStack.Client\ServiceClientBase.cs SendAll<TResponse>(requests)
            if (!(client is ServiceClientBase serviceClient))
                return client.SendAll<TResponse>(requests);

            var requestUri = serviceClient.SyncReplyBaseUri.WithTrailingSlash() + requestName + "[]";

            var response = serviceClient.Send<List<TResponse>>(HttpMethods.Post, requestUri, requests);

            return response;
        }

        private static IEnumerable<T[]> BatchesOf<T>(IEnumerable<T> sequence, int batchSize)
        {
            var batch = new List<T>(batchSize);

            foreach (var item in sequence)
            {
                batch.Add(item);
                if (batch.Count >= batchSize)
                {
                    yield return batch.ToArray();
                    batch.Clear();
                }
            }

            if (batch.Count > 0)
            {
                yield return batch.ToArray();
                batch.Clear();
            }
        }

        public static TResponse PostFileWithRequest<TResponse>(this IServiceClient client, string path, IReturn<TResponse> requestDto)
        {
            var fileToUpload = new FileInfo(path);

            using (var stream = fileToUpload.OpenRead())
            {
                return PostFileWithRequest(client, stream, fileToUpload.Name, requestDto);
            }
        }

        public static TResponse PostFileWithRequest<TResponse>(this IServiceClient client, Stream contentToUpload, string uploadedFileName, IReturn<TResponse> requestDto)
        {
            return client.PostFileWithRequest<TResponse>(contentToUpload, uploadedFileName, requestDto);
        }
    }
}
