using System;
using ServiceStack;

namespace Aquarius.Helpers
{
    public class SdkServiceClient : JsonServiceClient
    {
        public static TimeSpan? FirstByteReceivedTimeout { get; set; }
        public static TimeSpan? ReadEntireResponseTimeout { get; set; }

        static SdkServiceClient()
        {
            FirstByteReceivedTimeout = AppSettings.Get<TimeSpan?>(nameof(FirstByteReceivedTimeout), TimeSpan.FromMinutes(3));
            ReadEntireResponseTimeout = AppSettings.Get<TimeSpan?>(nameof(ReadEntireResponseTimeout), TimeSpan.FromMinutes(4));
        }

        public SdkServiceClient(string baseUri)
            :base(baseUri)
        {
            Timeout = FirstByteReceivedTimeout;
            ReadWriteTimeout = ReadEntireResponseTimeout;

            SetUserAgent();
        }

        public SdkServiceClient()
        {
            SetUserAgent();
        }

        private void SetUserAgent()
        {
            var components = new[]
            {
                UserAgent,
                UserAgentBuilder.GetSdkComponent(),
                UserAgentBuilder.GetApplicationComponent()
            };

            UserAgent = string.Join("/", components);
        }
    }
}
