using Aquarius.TimeSeries.Client;
using Aquarius.TimeSeries.Client.ServiceModels.Publish;
using FluentAssertions;
using NSubstitute;
using NUnit.Framework;
using ServiceStack;

#if AUTOFIXTURE4
using AutoFixture;
#else
using Ploeh.AutoFixture;
#endif

namespace Aquarius.Client.UnitTests.TimeSeries.Client
{
    [TestFixture]
    public class AccessTokenAuthenticatorTest : AuthenticatorTestBase<AccessTokenAuthenticator>
    {
        protected override IServiceClient CreateMockServiceClient()
        {
            return Substitute.For<IServiceClient>();
        }

        protected override AccessTokenAuthenticator CreateAuthenticator()
        {
            var authenticator = AccessTokenAuthenticator.Create("dummyhost") as AccessTokenAuthenticator;

            if (authenticator != null)
            {
                authenticator.Client = _mockServiceClient;
            }

            return authenticator;
        }

        [Test]
        public void Login_SetsClientBearerToken()
        {
            var authenticator = CreateAuthenticator();

            if (authenticator != null && authenticator is AccessTokenAuthenticator tokenAuthenticator)
            {
                var mockAccessToken = _fixture.Create<string>();
                authenticator.Login(mockAccessToken);
                
                tokenAuthenticator.Client.BearerToken.Should().BeEquivalentTo(mockAccessToken);
            }
        }

        [Test]
        public void Logout_CallsDeleteSession()
        {
            var authenticator = CreateAuthenticator();
            
            authenticator.Logout();

            _mockServiceClient.Received(1).Delete(Arg.Any<DeleteSession>());
        }
    }
}