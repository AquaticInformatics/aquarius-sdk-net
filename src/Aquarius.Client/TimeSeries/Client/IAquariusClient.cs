using System;
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

        ScopeAction SessionKeepAlive();
    }
}
