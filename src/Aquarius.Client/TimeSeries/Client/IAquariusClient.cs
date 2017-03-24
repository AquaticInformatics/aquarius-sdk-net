using System;
using System.Collections.Generic;
using System.Threading;
using ServiceStack;

namespace Aquarius.TimeSeries.Client
{
    public interface IAquariusClient : IDisposable
    {
        IServiceClient PublishClient { get; }
        IServiceClient AcquisitionClient { get; }
        IServiceClient ProvisioningClient { get; }

        AquariusServerVersion ServerVersion { get; }

        IServiceClient RegisterCustomClient(string baseUri);
        IServiceClient CloneAuthenticatedClient(IServiceClient client);
        IServiceClient CloneAuthenticatedClientWithOverrideMethod(IServiceClient client, string overrideMethod);

        IEnumerable<TResponse> SendBatchRequests<TRequest, TResponse>(IServiceClient client, int batchSize, IEnumerable<TRequest> requests, CancellationToken? cancellationToken = null)
            where TRequest : IReturn<TResponse>;

        ScopeAction SessionKeepAlive();
    }
}
