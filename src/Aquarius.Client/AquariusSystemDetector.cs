using System;
using System.Collections.Concurrent;
using Aquarius.Client.EndPoints;
using Aquarius.Client.ServiceModels.FieldData;
using ServiceStack;

namespace Aquarius.Client
{
    public class AquariusSystemDetector
    {
        private static readonly AquariusServerVersion Minimum3XVersion = AquariusServerVersion.Create("3");
        private static readonly AquariusServerVersion FirstNon3XVersion = AquariusServerVersion.Create("4");

        private readonly ConcurrentDictionary<string, AquariusServerVersion> _knownServerVersions = new ConcurrentDictionary<string, AquariusServerVersion>();

        private readonly Func<string, IServiceClient> _serviceClientFactory;

        public AquariusSystemDetector()
            : this(CreateJsonServiceClientWithQuickTimeouts)
        {
        }

        private static IServiceClient CreateJsonServiceClientWithQuickTimeouts(string baseUri)
        {
            return new JsonServiceClient(baseUri)
            {
                Timeout = TimeSpan.FromSeconds(10),
                ReadWriteTimeout = TimeSpan.FromSeconds(5)
            };
        }

        public AquariusSystemDetector(Func<string, IServiceClient> serviceClientFactory)
        {
            _serviceClientFactory = serviceClientFactory;
        }

        public AquariusServerType GetAquariusServerType(string hostname)
        {
            var serverVersion = GetAquariusServerVersion(hostname);

            if (serverVersion == null)
                return AquariusServerType.Unknown;

            if (serverVersion.IsLessThan(FirstNon3XVersion) && Minimum3XVersion.IsLessThan(serverVersion))
                return AquariusServerType.Legacy3X;

            return AquariusServerType.NextGeneration;
        }

        public AquariusServerVersion GetAquariusServerVersion(string hostname)
        {
            AquariusServerVersion aquariusServerVersion;

            if (_knownServerVersions.TryGetValue(hostname, out aquariusServerVersion))
                return aquariusServerVersion;

            aquariusServerVersion = DetectServerVersion(hostname);

            if (aquariusServerVersion != null)
            {
                _knownServerVersions.GetOrAdd(hostname, aquariusServerVersion);
            }

            return aquariusServerVersion;
        }

        private AquariusServerVersion DetectServerVersion(string hostname)
        {
            var internalFieldDataEndpoint = FieldData.ResolveEndpoint(hostname);

            try
            {
                using (var serviceClient = _serviceClientFactory(internalFieldDataEndpoint))
                {
                    return AquariusServerVersion.Create(serviceClient.Get(new GetVersion()).ApiVersion);
                }
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
