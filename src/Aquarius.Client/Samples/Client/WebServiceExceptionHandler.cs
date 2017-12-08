using System;
using System.Net;
using System.Runtime.Serialization;
using ServiceStack;

namespace Aquarius.Samples.Client
{
    public static class WebServiceExceptionHandler
    {
        public static SamplesApiException CreateSamplesApiExceptionFromResponse(WebServiceException e)
        {
            if (e.ResponseHeaders["server"] == "AmazonS3")
                return new SamplesMaintenanceModeException($"{e.Message}: AQUARIUS Samples is in maintenance mode", e);

            var errorResponse = DeserializeErrorFromResponse(e);
            var message = ComposeMessage(e, errorResponse);

            if (errorResponse?.ErrorCode == "gaia.domain.exceptions.AuthenticationException")
                return new SamplesAuthenticationException(message, e, errorResponse);

            return new SamplesApiException(message, e, errorResponse);
        }

        public static SamplesApiException CreateSamplesApiExceptionFromResponse(WebException e)
        {
            var response = e.Response as HttpWebResponse;
            var statusCode = (response == null) ? 0 : (int)response.StatusCode;
            var message = $"{e.Status}: {e.Message}";

            return new SamplesApiException(message, e)
            {
                StatusCode = statusCode,
                SamplesError = new SamplesErrorResponse
                {
                    ErrorCode = e.Status.ToString(),
                    Message = e.Message
                }
            };
        }

        private static SamplesErrorResponse DeserializeErrorFromResponse(WebServiceException e)
        {
            if (string.IsNullOrWhiteSpace(e.ResponseBody))
                return null;

            var contentType = e.ResponseHeaders[HttpResponseHeader.ContentType];
            if (!string.IsNullOrEmpty(contentType) && !contentType.ToLowerInvariant().Contains("application/json"))
                return null;

            return DeserializeErrorFromJson(e.ResponseBody);
        }

        private static SamplesErrorResponse DeserializeErrorFromJson(string responseBody)
        {
            try
            {
                return responseBody.FromJson<SamplesErrorResponse>();
            }
            catch (SerializationException)
            {
                return null;
            }
        }

        private static string ComposeMessage(WebServiceException e, SamplesErrorResponse errorResponse)
        {
            if (errorResponse?.Message == null)
                return e.Message;

            return $"{e.Message}: {errorResponse.Message}";
        }
    }
}
