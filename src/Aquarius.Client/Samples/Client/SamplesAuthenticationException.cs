using ServiceStack;

namespace Aquarius.Samples.Client
{
    public class SamplesAuthenticationException : SamplesApiException
    {
        public SamplesAuthenticationException(string message) : base(message)
        {
        }

        public SamplesAuthenticationException(string message, WebServiceException originalException)
            : base(message, originalException)
        {
        }

        public SamplesAuthenticationException(string message, WebServiceException originalException, SamplesErrorResponse errorResponse)
            : base(message, originalException, errorResponse)
        {
        }
    }
}
