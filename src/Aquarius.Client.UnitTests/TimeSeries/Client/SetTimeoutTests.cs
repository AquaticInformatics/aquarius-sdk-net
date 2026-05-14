using System;
using System.Net;
using Aquarius.TimeSeries.Client;
using Aquarius.TimeSeries.Client.Helpers;
using FluentAssertions;
using NUnit.Framework;
using ServiceStack;

namespace Aquarius.Client.UnitTests.TimeSeries.Client
{
    [TestFixture]
    public class SetTimeoutTests
    {
        private AquariusClient _client;

        [SetUp]
        public void BeforeEachTest()
        {
            _client = new AquariusClient(AuthenticationType.Credential)
            {
                ServerVersion = AquariusServerVersion.Create("0")
            };
        }

        [Test]
        public void SetTimeout_WithRequestTimeout_SetsTimeoutProperty()
        {
            var serviceClient = new JsonServiceClient("http://localhost");
            var timeout = TimeSpan.FromSeconds(300);

            _client.SetTimeout(serviceClient, timeout, null);

            serviceClient.Timeout.Should().Be(timeout);
        }

        [Test]
        public void SetTimeout_WithReadWriteTimeout_SetsReadWriteTimeoutProperty()
        {
            var serviceClient = new JsonServiceClient("http://localhost");
            var readWriteTimeout = TimeSpan.FromSeconds(600);

            _client.SetTimeout(serviceClient, null, readWriteTimeout);

            serviceClient.ReadWriteTimeout.Should().Be(readWriteTimeout);
        }

        [Test]
        public void SetTimeout_WithRequestTimeout_SetsRequestFilterThatAppliesToHttpWebRequest()
        {
            var serviceClient = new JsonServiceClient("http://localhost");
            var timeout = TimeSpan.FromSeconds(300);

            _client.SetTimeout(serviceClient, timeout, null);

            serviceClient.RequestFilter.Should().NotBeNull();

#if NET472
            var request = WebRequest.CreateHttp("http://localhost");
            serviceClient.RequestFilter(request);

            request.Timeout.Should().Be((int)timeout.TotalMilliseconds);
#endif
        }

        [Test]
        public void SetTimeout_WithReadWriteTimeout_SetsRequestFilterThatAppliesReadWriteToHttpWebRequest()
        {
            var serviceClient = new JsonServiceClient("http://localhost");
            var readWriteTimeout = TimeSpan.FromSeconds(600);

            _client.SetTimeout(serviceClient, null, readWriteTimeout);

            serviceClient.RequestFilter.Should().NotBeNull();

#if NET472
            var request = WebRequest.CreateHttp("http://localhost");
            serviceClient.RequestFilter(request);

            request.ReadWriteTimeout.Should().Be((int)readWriteTimeout.TotalMilliseconds);
#endif
        }

        [Test]
        public void SetTimeout_WithBothTimeouts_SetsBothOnHttpWebRequest()
        {
            var serviceClient = new JsonServiceClient("http://localhost");
            var timeout = TimeSpan.FromSeconds(300);
            var readWriteTimeout = TimeSpan.FromSeconds(600);

            _client.SetTimeout(serviceClient, timeout, readWriteTimeout);

#if NET472
            var request = WebRequest.CreateHttp("http://localhost");
            serviceClient.RequestFilter(request);

            request.Timeout.Should().Be((int)timeout.TotalMilliseconds);
            request.ReadWriteTimeout.Should().Be((int)readWriteTimeout.TotalMilliseconds);
#endif
        }

        [Test]
        public void SetTimeout_PreservesExistingRequestFilter()
        {
            var serviceClient = new JsonServiceClient("http://localhost");

#if NET472
            var existingFilterCalled = false;
            serviceClient.RequestFilter = _ => existingFilterCalled = true;
#endif

            _client.SetTimeout(serviceClient, TimeSpan.FromSeconds(300), null);

#if NET472
            var request = WebRequest.CreateHttp("http://localhost");
            serviceClient.RequestFilter(request);

            existingFilterCalled.Should().BeTrue();
#endif
        }

        [Test]
        public void SetTimeout_WithNullTimeouts_DoesNotSetTimeoutOnHttpWebRequest()
        {
            var serviceClient = new JsonServiceClient("http://localhost");

            _client.SetTimeout(serviceClient, null, null);

#if NET472
            var defaultTimeout = 100000; // .NET default HttpWebRequest.Timeout
            var defaultReadWriteTimeout = 300000; // .NET default HttpWebRequest.ReadWriteTimeout

            var request = WebRequest.CreateHttp("http://localhost");
            serviceClient.RequestFilter(request);

            request.Timeout.Should().Be(defaultTimeout);
            request.ReadWriteTimeout.Should().Be(defaultReadWriteTimeout);
#endif
        }

        [Test]
        public void SetTimeout_WithNonServiceClientBase_DoesNotThrow()
        {
            var mockClient = NSubstitute.Substitute.For<IServiceClient>();

            Assert.DoesNotThrow(() => _client.SetTimeout(mockClient, TimeSpan.FromSeconds(300), null));
        }
    }
}
