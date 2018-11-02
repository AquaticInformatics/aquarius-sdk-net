using System;
using Aquarius.TimeSeries.Client;
using NSubstitute;
using NUnit.Framework;
using ServiceStack;
using DeleteSession = Aquarius.TimeSeries.Client.ServiceModels.Publish.DeleteSession;
using PostSession = Aquarius.TimeSeries.Client.ServiceModels.Publish.PostSession;
using GetPublicKey = Aquarius.TimeSeries.Client.ServiceModels.Publish.GetPublicKey;
using PublicKey = Aquarius.TimeSeries.Client.ServiceModels.Publish.PublicKey;

#if AUTOFIXTURE4
using AutoFixture;
#else
using Ploeh.AutoFixture;
#endif

namespace Aquarius.Client.UnitTests.TimeSeries.Client
{
    [TestFixture]
    public class AuthenticatorTests
    {
        private IFixture _fixture;
        private IServiceClient _mockServiceClient;

        [SetUp]
        public void BeforeEachTest()
        {
            _fixture = new Fixture();
            _mockServiceClient = CreateMockServiceClient();

            ConfigureSystemDetectorWithMockServiceClient();
        }

        private IServiceClient CreateMockServiceClient()
        {
            var mockServiceClient = Substitute.For<IServiceClient>();

            mockServiceClient
                .Get(Arg.Any<GetPublicKey>())
                .Returns(new PublicKey
                {
                    KeySize = 1024,
                    Xml = "<RSAKeyValue><Modulus>3GmH/grhUyuiWlBDhNliZN3PYy2JPxJ5nG4t1CmQW8ZGPSsWY1AYIEU3b0A7eKOL3BbAiQzn0GpaSU9HT452zKhqXE+G2nxw7Y0tJYfBzsTbBSPcHaUTHd/YyqDwDhuuJ+RrCqQfgnkq+YXnlCU1CJwVlF5HUyLWWHaUgaNlEqs=</Modulus><Exponent>AQAB</Exponent></RSAKeyValue>"
                });

            mockServiceClient
                .Post(Arg.Any<PostSession>())
                .Returns(Guid.NewGuid().ToString("N"));

            return mockServiceClient;
        }

        private void ConfigureSystemDetectorWithMockServiceClient()
        {
            var detector = AquariusSystemDetector.Instance;

            detector.ServiceClientFactory = s => _mockServiceClient;
            detector.Reset();
        }

        [Test]
        public void Login_SendsExpectedRequests()
        {
            var authenticator = CreateAuthenticator();

            authenticator.Login(_fixture.Create<string>(), _fixture.Create<string>());

            _mockServiceClient
                .Received(1)
                .Get(Arg.Any<GetPublicKey>());

            _mockServiceClient
                .Received(1)
                .Post(Arg.Any<PostSession>());
        }

        [Test]
        public void Logout_WithNgConnection_CallsDeleteSession()
        {
            SetupMockToReturnApiVersion("16.1");

            var authenticator = CreateAuthenticator();
            
            authenticator.Logout();

            AssertExpectedDeleteSessionRequests(1);
        }

        [Test]
        public void Logout_With3xConnection_DoesNotCallDeleteSession()
        {
            SetupMockToReturnApiVersion("3.10");

            var authenticator = CreateAuthenticator();

            authenticator.Logout();

            AssertExpectedDeleteSessionRequests(0);
        }

        private IAuthenticator CreateAuthenticator()
        {
            var authenticator = Authenticator.Create("dummyhost") as Authenticator;

            if (authenticator != null)
            {
                authenticator.Client = _mockServiceClient;
            }

            return authenticator;
        }

        private void SetupMockToReturnApiVersion(string apiVersion)
        {
            _mockServiceClient
                .Get(Arg.Any<AquariusSystemDetector.GetVersion>())
                .ReturnsForAnyArgs(new AquariusSystemDetector.VersionResponse {ApiVersion = apiVersion});
        }

        private void AssertExpectedDeleteSessionRequests(int count)
        {
            _mockServiceClient
                .Received(count)
                .Delete(Arg.Any<DeleteSession>());
        }
    }
}
