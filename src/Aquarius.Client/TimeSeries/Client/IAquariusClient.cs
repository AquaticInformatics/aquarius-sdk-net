using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading;
using ServiceStack;

namespace Aquarius.TimeSeries.Client
{
    public interface IAquariusClient : IDisposable
    {
        IServiceClient Publish { get; }
        IServiceClient Acquisition { get; }
        IServiceClient Provisioning { get; }

        [Obsolete("Use the Publish property instead."), EditorBrowsable(EditorBrowsableState.Never)]
        IServiceClient PublishClient { get; }
        [Obsolete("Use the Acquisition property instead."), EditorBrowsable(EditorBrowsableState.Never)]
        IServiceClient AcquisitionClient { get; }
        [Obsolete("Use the Provisioning property instead."), EditorBrowsable(EditorBrowsableState.Never)]
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
