using System;
using System.Collections.Generic;
using ServiceStack;

namespace Aquarius.TimeSeries.Client
{
    public interface IAquariusClient : IDisposable
    {
        IServiceClient PublishClient { get; }
        IServiceClient AcquisitionClient { get; }
        IServiceClient ProvisioningClient { get; }

        IServiceClient RegisterCustomClient(string baseUri);
        IServiceClient CloneAuthenticatedClient(IServiceClient client);
        IServiceClient CloneAuthenticatedClientWithOverrideMethod(IServiceClient client, string overrideMethod);

        IEnumerable<TResponse> SendBatchRequests<TRequest, TResponse>(IServiceClient client, int batchSize, IEnumerable<TRequest> requests)
            where TRequest : IReturn<TResponse>;

        ScopeAction SessionKeepAlive();
    }
}
