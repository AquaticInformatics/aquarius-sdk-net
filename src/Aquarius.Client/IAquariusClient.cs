using System;
using ServiceStack;

namespace Aquarius.Client
{
    public interface IAquariusClient : IDisposable
    {
        IServiceClient PublishClient { get; }
        IServiceClient AcquisitionClient { get; }
        IServiceClient ProvisioningClient { get; }
        IServiceClient ProcessorClient { get; }
        IServiceClient FieldDataClient { get; }

        ScopeAction SessionKeepAlive();
    }
}
