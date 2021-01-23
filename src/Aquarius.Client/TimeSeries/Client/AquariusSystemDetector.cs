using System;
using System.Collections.Concurrent;
#if NETFRAMEWORK
using System.Configuration;
#endif
using System.Diagnostics;
using System.Net;
using System.Reflection;
using Aquarius.Helpers;
using Aquarius.TimeSeries.Client.EndPoints;
using ServiceStack;
using ServiceStack.Logging;

namespace Aquarius.TimeSeries.Client
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

        public static TimeSpan FirstByteReceivedTimeout = TimeSpan.FromSeconds(10);
        public static TimeSpan ReadEntireResponseTimeout = TimeSpan.FromSeconds(5);
        public static int MaximumRetryCount = 3;

        private static readonly AquariusServerVersion Minimum3XVersion = AquariusServerVersion.Create("3");
        private static readonly AquariusServerVersion FirstNon3XVersion = AquariusServerVersion.Create("4");

        private readonly ConcurrentDictionary<string, AquariusServerVersion> _knownServerVersions = new ConcurrentDictionary<string, AquariusServerVersion>();
        private readonly ConcurrentDictionary<string, AquariusServerVersion> _overrideVersions = new ConcurrentDictionary<string, AquariusServerVersion>();

        internal Func<string, IServiceClient> ServiceClientFactory { get; set; }

        public static readonly AquariusSystemDetector Instance = new AquariusSystemDetector();

        private AquariusSystemDetector()
        {
            ServiceClientFactory = CreateJsonServiceClientWithQuickTimeouts;

            InitializeOverrides();
        }

        public void Reset()
        {
            _knownServerVersions.Clear();
            _overrideVersions.Clear();
        }

        private static IServiceClient CreateJsonServiceClientWithQuickTimeouts(string baseUri)
        {
            return new SdkServiceClient(baseUri)
            {
                Timeout = FirstByteReceivedTimeout,
                ReadWriteTimeout = ReadEntireResponseTimeout
            };
        }

        private void InitializeOverrides()
        {
            var overridesValue = AppSettings.Get("SystemDetectorOverrides", string.Empty);
            SetOverrides(overridesValue);
        }

        public void SetOverrides(string overridesValue)
        {
            if (string.IsNullOrEmpty(overridesValue))
                return;

            foreach (var text in overridesValue.Split(OverrideSeparators, StringSplitOptions.RemoveEmptyEntries))
            {
                var components = text.Split('=');
                if (components.Length != 2)
                    continue;

                var hostname = components[0].Trim();
                var version = components[1].Trim();

                _overrideVersions[hostname] = AquariusServerVersion.Create(version);
            }
        }

        private static readonly char[] OverrideSeparators = {',', ';'};

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

            if (_overrideVersions.TryGetValue(hostname, out aquariusServerVersion))
            {
                Log.WarnFormat("Version probe bypassed for hostname={0}. Using fakeVersion={1}", hostname, aquariusServerVersion);

                _knownServerVersions.GetOrAdd(hostname, aquariusServerVersion);

                return aquariusServerVersion;
            }

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

            var attemptCount = 1;

            while (true)
            {
                var stopwatch = Stopwatch.StartNew();

                try
                {
                    using (var serviceClient = ServiceClientFactory(versionEndpoint))
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

                    var webException = exception as WebException;
                    if (webException != null && (webException.Status == WebExceptionStatus.Timeout) && (attemptCount < MaximumRetryCount))
                    {
                        Log.InfoFormat("Version probe attempt #{0} for '{1}'", attemptCount, hostname);
                        ++attemptCount;
                        continue;
                    }

                    return null;
                }
            }
        }
    }
}
