using System.Collections.Generic;
using Aquarius.TimeSeries.Client.NativeTypes;
using FluentAssertions;
using NSubstitute;
using NSubstitute.ExceptionExtensions;
using NUnit.Framework;
using ServiceStack;

namespace Aquarius.Client.UnitTests.TimeSeries.Client.NativeTypes
{
    [TestFixture]
    public class ServerRequestNameResolverTests
    {
        private IServiceClient _mockEndpointClient;
        private ServerRequestNameResolver _resolver;

        [SetUp]
        public void BeforeEachTest()
        {
            _mockEndpointClient = CreateMockServiceClient();

            _resolver = new ServerRequestNameResolver();
        }

        private IServiceClient CreateMockServiceClient()
        {
            var mockServiceClient = Substitute.For<IServiceClient>();

            return mockServiceClient;
        }

        private const string KnownRoute = "/items/path";
        [Route(KnownRoute, HttpMethods.Get)]
        public class ClientGetRequest : IReturn<DummyResponse>
        {
        }

        [Route(KnownRoute, HttpMethods.Get)]
        public class RenamedServerGetRequest : IReturn<DummyResponse>
        {
        }

        public class DummyResponse
        {
        }

        [Route(KnownRoute + "/subpath", HttpMethods.Get)]
        public class UnknownGetRequest : IReturn<DummyResponse>
        {
        }

        private void SetupMockEndpointWithRenamedMetadata()
        {
            _mockEndpointClient
                .Get(Arg.Any<GetTypesMetadata>())
                .Returns(new MetadataTypes
                {
                    Operations = new List<MetadataOperationType>
                    {
                        new MetadataOperationType
                        {
                            Request = new MetadataType
                            {
                                Name = typeof(RenamedServerGetRequest).Name,
                                Routes = new List<MetadataRoute>
                                {
                                    new MetadataRoute
                                    {
                                        Path = KnownRoute
                                    }
                                }
                            }
                        }
                    }
                });
        }

        private void SetupMockEndPointWithoutMetadata()
        {
            _mockEndpointClient
                .Get(Arg.Any<GetTypesMetadata>())
                .Throws(new WebServiceException("Nope"));
        }

        [Test]
        public void ResolveRequestName_WhenCalledTwice_OnlyFetchesMetadataOnce()
        {
            SetupMockEndpointWithRenamedMetadata();

            _resolver.ResolveRequestName(_mockEndpointClient, new ClientGetRequest());
            _resolver.ResolveRequestName(_mockEndpointClient, new ClientGetRequest());

            _mockEndpointClient
                .Received(1)
                .Get(Arg.Any<GetTypesMetadata>());
        }

        [Test]
        public void ResolveRequestName_WithRenamedRequestClass_ReturnsRenamedServerRequestName()
        {
            SetupMockEndpointWithRenamedMetadata();

            var request = new ClientGetRequest();
            var clientRequestName = request.GetType().Name;

            var actual = _resolver.ResolveRequestName(_mockEndpointClient, request);
            var expected = typeof(RenamedServerGetRequest).Name;

            actual.Should().NotBe(clientRequestName);
            actual.ShouldBeEquivalentTo(expected);
        }

        [Test]
        public void ResolveRequestName_WithUnknownRequestClass_ReturnsClientRequestName()
        {
            SetupMockEndpointWithRenamedMetadata();

            var request = new UnknownGetRequest();
            var clientRequestName = request.GetType().Name;

            var actual = _resolver.ResolveRequestName(_mockEndpointClient, request);
            var expected = clientRequestName;

            actual.ShouldBeEquivalentTo(expected);
        }

        [Test]
        public void ResolveRequestName_WithNoMetadata_ReturnsClientRequestName()
        {
            SetupMockEndPointWithoutMetadata();

            var request = new ClientGetRequest();
            var clientRequestName = request.GetType().Name;

            var actual = _resolver.ResolveRequestName(_mockEndpointClient, request);
            var expected = clientRequestName;

            actual.ShouldBeEquivalentTo(expected);
        }
    }
}
