using System;
using System.Collections.Concurrent;
using System.Diagnostics;
using System.Net;
using System.Reflection;
using Aquarius.Client.EndPoints;
using ServiceStack;
using ServiceStack.Logging;

namespace Aquarius.Client
{
    public class AquariusSystemDetector
    {
        private static readonly ILog Log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        [Route("/version", "GET")]
        public class GetVersion
            : IReturn<VersionResponse>
        {
        }

        public class VersionResponse
        {
            public string ApiVersion { get; set; }
        }

        public static TimeSpan ConnectionTimeout = TimeSpan.FromSeconds(10);
        public static TimeSpan ReadWriteTimeout = TimeSpan.FromSeconds(30);

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
                Timeout = ConnectionTimeout,
                ReadWriteTimeout = ReadWriteTimeout
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

            // TODO: TSS-19 Now that we know it is an NG server, we can add a quick HTTPS-probe when hostname has no explicit scheme

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
            var versionBaseUri = Root.EndPoint + "/apps/v1";
            var versionEndpoint = UriHelper.ResolveEndpoint(hostname, versionBaseUri);

            var stopwatch = Stopwatch.StartNew();

            try
            {
                using (var serviceClient = _serviceClientFactory(versionEndpoint))
                {
                    return AquariusServerVersion.Create(serviceClient.Get(new GetVersion()).ApiVersion);
                }
            }
            catch (Exception exception)
            {
                var message = string.Format(
                    "Unknown server version '{0}' after {1:F3} seconds. {2}",
                    hostname,
                    stopwatch.Elapsed.TotalSeconds,
                    exception.Message);

                var isExpectedException =
                    exception is NotSupportedException ||
                    exception is WebException ||
                    exception is WebServiceException;

                if (isExpectedException)
                {
                    Log.Warn(message);
                }
                else
                {
                    Log.Warn(message, exception);
                }

                return null;
            }
        }
    }
}
