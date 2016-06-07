using System;
using System.Threading;
using ServiceStack;

namespace Aquarius.Client
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
    }
}
