using System;
using System.Globalization;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using ServiceStack;

namespace Aquarius.Samples.Client
{
    public class FileUploader
    {
        private readonly IRestClient _restClient;

        public static FileUploader Create(IServiceClient client)
        {
            var baseUri = string.Empty;
            var authHeader = string.Empty;
            var userAgent = string.Empty;

            if (client is JsonServiceClient jsonServiceClient)
            {
                baseUri = jsonServiceClient.BaseUri;
                authHeader = jsonServiceClient.Headers[SamplesClient.AuthorizationHeaderKey];
                userAgent = jsonServiceClient.UserAgent;
            }

            return new FileUploader(new JsonHttpClient(baseUri), authHeader, userAgent);
        }

        public FileUploader(IRestClient restClient, string authorizationHeader, string userAgent)
        {
            _restClient = restClient;
            _restClient.AddHeader(SamplesClient.AuthorizationHeaderKey, authorizationHeader);
            _restClient.AddHeader("User-Agent", userAgent);
        }

        public TResponse PostFileWithRequest<TResponse>(
            string relativeOrAbsoluteUri,
            Stream contentToUpload,
            string uploadedFileName,
            IReturn<TResponse> requestDto,
            HttpContent extraContent = null,
            string extraContentName = null)
        {
            var multipartContent = CreateMultipartContent(relativeOrAbsoluteUri, contentToUpload, uploadedFileName);

            if (extraContent != null && extraContentName != null)
            {
                AddFormDataContent(multipartContent, extraContent, extraContentName);
            }

            return _restClient.Post<TResponse>(
                ComposePostUrlWithQueryParams(relativeOrAbsoluteUri, requestDto),
                multipartContent);
        }

        private string ComposePostUrlWithQueryParams<TResponse>(
            string relativeOrAbsoluteUri,
            IReturn<TResponse> requestDto)
        {
            var queryString = QueryStringSerializer.SerializeToString(requestDto);

            var uriBuilder = new UriBuilder(relativeOrAbsoluteUri) {Query = queryString};

            return uriBuilder.ToString();
        }

        private MultipartContent CreateMultipartContent(
            string relativeOrAbsoluteUri,
            Stream contentToUpload,
            string uploadedFilename)
        {
            return IsImportServiceUpload(relativeOrAbsoluteUri)
                ? CreateImportServiceUploadContent(contentToUpload, uploadedFilename)
                : CreateFineUploaderContent(contentToUpload, uploadedFilename);
        }

        internal static bool IsImportServiceUpload(string relativeOrAbsoluteUri)
        {
            // TODO: We need a better way to distinguish between file upload request types
            const string importServiceRoute = "/services/import/";

            return relativeOrAbsoluteUri.ToLowerInvariant().Contains(importServiceRoute);
        }

        private static MultipartFormDataContent CreateImportServiceUploadContent(Stream contentToUpload, string uploadedFilename)
        {
            return CreateMultipartContent(contentToUpload, uploadedFilename, "file");
        }

        private static MultipartFormDataContent CreateFineUploaderContent(Stream contentToUpload, string uploadedFilename)
        {
            return CreateMultipartContent(contentToUpload, uploadedFilename, "qqfile", (content, contentBytes) =>
            {
                AddFormDataContent(content, new StringContent(uploadedFilename), "qqfilename");
                AddFormDataContent(content, new StringContent(Guid.NewGuid().ToString("D")), "qquuid");
                AddFormDataContent(content, new StringContent(contentBytes.Length.ToString(CultureInfo.InvariantCulture)), "qqtotalfilesize");
            });
        }

        private static MultipartFormDataContent CreateMultipartContent(
            Stream contentToUpload,
            string uploadedFilename,
            string contentFieldName,
            Action<MultipartFormDataContent, byte[]> contentSizeAction = null)
        {
            var content = new MultipartFormDataContent();

            var fileBytes = contentToUpload.ReadFully();

            contentSizeAction?.Invoke(content, fileBytes);

            var fileContent = new ByteArrayContent(fileBytes, 0, fileBytes.Length);

            AddFormDataContent(content, fileContent, contentFieldName);

            fileContent.Headers.ContentDisposition.FileName = uploadedFilename;
            fileContent.Headers.ContentType = MediaTypeHeaderValue.Parse(MimeTypes.GetMimeType(uploadedFilename));

            return content;
        }

        private static void AddFormDataContent(MultipartContent content, HttpContent partContent, string partName)
        {
            partContent.Headers.ContentDisposition = new ContentDispositionHeaderValue("form-data")
                { Name = partName };
            content.Add(partContent);
        }
    }
}
