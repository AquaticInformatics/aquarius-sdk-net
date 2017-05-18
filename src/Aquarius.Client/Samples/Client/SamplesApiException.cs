using System;
using ServiceStack;

namespace Aquarius.Samples.Client
{
    public class SamplesApiException : Exception, IHasStatusCode
    {
        public SamplesApiException(string message) : base(message)
        {
        }

        public SamplesApiException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        public SamplesApiException(string message, WebServiceException originalException)
            : base(message, originalException)
        {
            StatusCode = originalException.StatusCode;
        }

        public SamplesApiException(string message, WebServiceException originalException, SamplesErrorResponse errorResponse)
            : base(message, originalException)
        {
            StatusCode = originalException.StatusCode;
            SamplesError = errorResponse;
        }

        public int StatusCode { get; set; }
        public SamplesErrorResponse SamplesError { get; set; }
    }
}
