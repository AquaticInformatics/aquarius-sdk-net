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
        private readonly JsonServiceClient _client;

        public FileUploader(JsonServiceClient client)
        {
            _client = client;
        }

        public TResponse PostFileWithRequest<TResponse>(Stream contentToUpload, string uploadedFileName, IReturn<TResponse> requestDto)
        {
            using (var httpClient = new JsonHttpClient(_client.BaseUri))
            {
                httpClient.Headers.Add(SamplesClient.AuthorizationHeader, _client.Headers[SamplesClient.AuthorizationHeader]);
                httpClient.Headers.Add("User-Agent", _client.UserAgent);

                return httpClient.Post<TResponse>(
                    ComposePostUrlWithQueryParams(requestDto),
                    CreateMultipartContent(contentToUpload, uploadedFileName, requestDto));
            }
        }

        private string ComposePostUrlWithQueryParams<TResponse>(IReturn<TResponse> requestDto)
        {
            var queryString = QueryStringSerializer.SerializeToString(requestDto);

            var uriBuilder = new UriBuilder(GetPostUrl(requestDto)) {Query = queryString};

            return uriBuilder.ToString();
        }

        private string GetPostUrl<TResponse>(IReturn<TResponse> requestDto)
        {
            return _client.ResolveTypedUrl(HttpMethods.Post, requestDto);
        }

        private MultipartContent CreateMultipartContent<TResponse>(Stream contentToUpload,
            string uploadedFilename, IReturn<TResponse> requestDto)
        {
            // TODO: We need a better way to distinguish between file upload request types
            const string importServiceRoute = "/services/import/";

            var url = GetPostUrl(requestDto).ToLowerInvariant();

            return url.Contains(importServiceRoute)
                ? CreateImportServiceUploadContent(contentToUpload, uploadedFilename)
                : CreateFineUploaderContent(contentToUpload, uploadedFilename);
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
