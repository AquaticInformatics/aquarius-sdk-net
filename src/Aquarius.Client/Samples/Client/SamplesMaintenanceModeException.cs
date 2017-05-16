using ServiceStack;

namespace Aquarius.Samples.Client
{
    public class SamplesMaintenanceModeException : SamplesApiException
    {
        public SamplesMaintenanceModeException(string message) : base(message)
        {
        }

        public SamplesMaintenanceModeException(string message, WebServiceException originalException)
            : base(message, originalException)
        {
        }
    }
}
