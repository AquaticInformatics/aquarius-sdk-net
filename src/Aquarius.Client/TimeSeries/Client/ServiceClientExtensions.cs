using System;
using System.Collections.Generic;
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

        public static IEnumerable<TResponse> SendAll<TRequest, TResponse>(this IServiceClient client, int batchSize, IEnumerable<TRequest> requests)
            where TRequest : IReturn<TResponse>
        {
            var responses = new List<TResponse>();

            var requestBatches = BatchesOf(requests, batchSize);

            foreach (var requestBatch in requestBatches)
            {
                responses.AddRange(client.SendAll<TResponse>(requestBatch.Cast<object>()));
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
    }
}
