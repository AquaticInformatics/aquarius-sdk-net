using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
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

        public static IEnumerable<TResponse> SendAll<TRequest, TResponse>(
            this IServiceClient client,
            int batchSize,
            IEnumerable<TRequest> requests,
            CancellationToken? cancellationToken = null)
            where TRequest : IReturn<TResponse>
        {
            var responses = new List<TResponse>();

            var requestBatches = BatchesOf(requests, batchSize);

            foreach (var requestBatch in requestBatches)
            {
                responses.AddRange(client.SendAll<TResponse>(requestBatch.Cast<object>()));

                if (cancellationToken.HasValue && cancellationToken.Value.IsCancellationRequested)
                    break;
            }

            return responses;
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
