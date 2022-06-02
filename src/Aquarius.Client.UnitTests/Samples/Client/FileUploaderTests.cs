using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using Aquarius.Samples.Client;
using Aquarius.Samples.Client.ServiceModel;
using Aquarius.TimeSeries.Client;
using FluentAssertions;
using NSubstitute;
using NUnit.Framework;
using ServiceStack;

#if AUTOFIXTURE4
using AutoFixture;
#else
using Ploeh.AutoFixture;
#endif

namespace Aquarius.UnitTests.Samples.Client
{
    [TestFixture]
    [Ignore(@"
FileUploader tests fail when targeting net6.0 due to ServiceStack dependencies.
ServiceStack.HttpClient.Core package (6.0.0 and higher) targets net6.0 and netstandard2.0.
In netstandard2.0:
    JsonHttpClient [ServiceStack.HttpClient.dll]
    -> ResultsFilterHttpResponseDelegate [ServiceStack.HttpClient.dll]
In net6.0:
    JsonHttpClient [ServiceStack.HttpClient.dll]
    -> ResultsFilterHttpResponseDelegate [ServiceStack.Client.dll]")]
    public class FileUploaderTests
    {
        [OneTimeSetUp]
        public void BeforeAnyTests()
        {
            ServiceStackConfig.ConfigureServiceStack();
        }

        private IFixture _fixture;

        private string _mockAuthorizationHeaderValue;
        private string _mockUserAgent;
        private string _mockFilename;
        private int _mockFileSize;
        private IRestClient _mockRestClient;

        private FileUploader _uploader;

        [SetUp]
        public void BeforeEachTest()
        {
            _fixture = new Fixture();
            _mockAuthorizationHeaderValue = _fixture.Create<string>();
            _mockUserAgent = _fixture.Create<string>();
            _mockFilename = _fixture.Create<string>()+".csv";
            _mockFileSize = _fixture.Create<int>();
            _mockRestClient = Substitute.For<IRestClient>();

            _uploader = new FileUploader(_mockRestClient, _mockAuthorizationHeaderValue, _mockUserAgent);
        }

        private static readonly IEnumerable<TestCaseData> ImportServiceRouteTests = new[]
        {
            new TestCaseData(new PostUploadAttachment().ToPostUrl(), false),
            new TestCaseData(new PostImportAnalysisMethods().ToPostUrl(), true),
        };

        [TestCaseSource(nameof(ImportServiceRouteTests))]
        public void IsImportServiceRoute_DetectsImportServiceRoutesCorrectly(string relativeOrAbsoluteUri, bool expected)
        {
            var actual = FileUploader.IsImportServiceUpload(relativeOrAbsoluteUri);
            actual.ShouldBeEquivalentTo(expected);

            if (actual)
            {
                FileUploader.IsImportServiceUpload(relativeOrAbsoluteUri.ToLowerInvariant()).ShouldBeEquivalentTo(true, "Lowercase of URL should also be true");
                FileUploader.IsImportServiceUpload(relativeOrAbsoluteUri.ToUpperInvariant()).ShouldBeEquivalentTo(true, "Uppercase of URL should also be true");
            }
        }

        [Test]
        public void ctor_ConfiguresRequestHeadersCorrectly()
        {
            _mockRestClient
                .Received(1)
                .AddHeader(Arg.Is(SamplesClient.AuthorizationHeaderKey), Arg.Is(_mockAuthorizationHeaderValue));

            _mockRestClient
                .Received(1)
                .AddHeader(Arg.Is("User-Agent"), Arg.Is(_mockUserAgent));
        }

        [Test]
        public void PostFileWithRequest_WithAttachmentRequest_PostsFineUploaderContent()
        {
            AssertPostFileComposesMultiPartRequest(new PostUploadAttachment());
        }

        [Test]
        public void PostFileWithRequest_WithImportServiceRequest_PostsImportServiceContent()
        {
            AssertPostFileComposesMultiPartRequest(new PostImportAnalysisMethods());
        }

        private void AssertPostFileComposesMultiPartRequest<TResponse>(IReturn<TResponse> requestDto)
        {
            var postUrl = $"http://somehost{requestDto.ToPostUrl()}";
            var queryString = QueryStringSerializer.SerializeToString(requestDto);
            var isImport = FileUploader.IsImportServiceUpload(postUrl);
            var streamToUpload = CreateMemoryStream(_mockFileSize);

            _uploader.PostFileWithRequest(postUrl, streamToUpload, _mockFilename, requestDto);

            var expectedUri = new UriBuilder(postUrl) {Query = queryString}.ToString();

            if (isImport)
            {
                _mockRestClient
                    .Received(1)
                    .Post<TResponse>(Arg.Is(expectedUri), Arg.Is<object>(content => IsImportServiceContent(content)));
            }
            else
            {
                _mockRestClient
                    .Received(1)
                    .Post<TResponse>(Arg.Is(expectedUri), Arg.Is<object>(content => IsFineUploaderContent(content)));
            }
        }

        private static Stream CreateMemoryStream(int byteCount)
        {
            return new MemoryStream(new byte[byteCount]);
        }

        private bool IsFineUploaderContent(object content)
        {
            var parts = AssertMultipartFormContent(content, "qqfile");

            if (parts == null)
                return false;

            var uuidContent = parts.Single(p => p is StringContent && p.Headers.ContentDisposition.Name == "qquuid");
            var uuidText = uuidContent.ReadAsStringAsync().Result;
            Guid dummy;
            Guid.TryParseExact(uuidText, "D", out dummy).ShouldBeEquivalentTo(true, $"Can't parse {uuidText} as a GUID");

            var filenameContent = parts.Single(p => p is StringContent && p.Headers.ContentDisposition.Name == "qqfilename");
            filenameContent.ReadAsStringAsync().Result.ShouldBeEquivalentTo(_mockFilename, "Filenames should match");

            var totalSizeContent = parts.Single(p => p is StringContent && p.Headers.ContentDisposition.Name == "qqtotalfilesize");
            var totalSize = int.Parse(totalSizeContent.ReadAsStringAsync().Result);
            totalSize.ShouldBeEquivalentTo(_mockFileSize, "Total file sizes should match");

            return true;
        }

        private bool IsImportServiceContent(object content)
        {
            var parts = AssertMultipartFormContent(content, "file");

            return parts != null;
        }

        private List<HttpContent> AssertMultipartFormContent(object content, string expectedName)
        {
            var multipartFormDataContent = content as MultipartFormDataContent;

            if (multipartFormDataContent == null)
                return null;

            var parts = multipartFormDataContent.ToList();

            if (!parts.Any())
                return null;

            if (parts.Any(p => p.Headers.ContentDisposition.DispositionType != "form-data"))
                return null;

            var fileContent = parts.Last() as ByteArrayContent;

            if (fileContent == null)
                return null;

            var bytes = fileContent.ReadAsByteArrayAsync().Result;
            bytes.Length.ShouldBeEquivalentTo(_mockFileSize, "Content size should match");

            fileContent.Headers.ContentDisposition.FileName.ShouldBeEquivalentTo(_mockFilename, "Uploaded filename should match");
            fileContent.Headers.ContentDisposition.Name.ShouldBeEquivalentTo(expectedName, "Name field should match");

            return parts;
        }
    }
}
