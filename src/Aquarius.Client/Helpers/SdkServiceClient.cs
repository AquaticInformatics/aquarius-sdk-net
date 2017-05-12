using ServiceStack;

namespace Aquarius.Helpers
{
    public class SdkServiceClient : JsonServiceClient
    {
        public SdkServiceClient(string baseUri)
            :base(baseUri)
        {
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
