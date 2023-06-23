using Aquarius.TimeSeries.Client;
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
    public abstract class AuthenticatorTestBase<TAuthenticator>
        where TAuthenticator : IAuthenticator
    {
        protected IFixture _fixture;
        protected IServiceClient _mockServiceClient;

        [SetUp]
        public void BeforeEach()
        {
            _fixture = new Fixture();
            _mockServiceClient = CreateMockServiceClient();
            
            ConfigureSystemDetectorWithMockServiceClient();
        }

        protected abstract IServiceClient CreateMockServiceClient();

        protected abstract TAuthenticator CreateAuthenticator();

        protected void ConfigureSystemDetectorWithMockServiceClient()
        {
            var detector = AquariusSystemDetector.Instance;

            detector.ServiceClientFactory = s => _mockServiceClient;
            detector.Reset();
        }
    }
}