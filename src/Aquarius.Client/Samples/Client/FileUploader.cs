using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using ServiceStack;

namespace Aquarius.Samples.Client
{
    public class FileUploader
    {
        private readonly IRestClient _restClient;

        public string LocationResponseHeader { get; private set; } 

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

            if (_restClient is JsonHttpClient jhc)
            {
                jhc.ResultsFilterResponse = (response, o, method, uri, request) =>
                    LocationResponseHeader = response.Headers?.Location.ToString();
            }
        }

        public void PostFileWithRequest<TRequest>(
            string relativeOrAbsoluteUri,
            Stream contentToUpload,
            string uploadedFileName,
            TRequest requestDto,
            HttpContent extraContent = null,
            string extraContentName = null) where TRequest : IReturnVoid
        {
            var multipartContent = CreateMultipartContent(relativeOrAbsoluteUri, contentToUpload, uploadedFileName);

            if (extraContent != null && extraContentName != null)
            {
                AddFormDataContent(multipartContent, extraContent, extraContentName);
            }

            _restClient.Post<IReturnVoid>(
                ComposePostUrlWithQueryParams(relativeOrAbsoluteUri, requestDto),
                multipartContent);
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

        private string ComposePostUrlWithQueryParams(
            string relativeOrAbsoluteUri,
            object requestDto)
        {
            var queryString = ComposeCamelCaseQueryString(requestDto);

            var uriBuilder = new UriBuilder(relativeOrAbsoluteUri) {Query = queryString};

            return uriBuilder.ToString();
        }

        private string ComposeCamelCaseQueryString(object requestDto)
        {
            var queryString = QueryStringSerializer.SerializeToString(requestDto);

            if (string.IsNullOrWhiteSpace(queryString))
                return queryString;

            var x = queryString
                .Split(ParameterSeparators)
                .Select(SplitPair)
                .ToList();

            return string.Join("&", x.Select(p => $"{p.Key.ToCamelCase()}={p.Value}"));
        }

        private static (string Key, string Value) SplitPair(string parameter)
        {
            var parts = parameter.Split(PairSeparators, 2);

            return (parts[0], parts.Length > 1 ? parts[1] : null);

        }

        private static readonly char[] ParameterSeparators = {'&'};
        private static readonly char[] PairSeparators = { '=' };

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
            var lowercaseRoute = relativeOrAbsoluteUri.ToLowerInvariant();

            return KnownImportServiceRoutes
                .Any(route => lowercaseRoute.Contains(route));
        }

        private static readonly List<string> KnownImportServiceRoutes = new List<string>
        {
            "/services/import/",
            "/v2/observationimports"
        };

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
