using Aquarius.TimeSeries.Client;
using Aquarius.TimeSeries.Client.ServiceModels.Publish;
using NSubstitute;
using NUnit.Framework;
using ServiceStack;

namespace Aquarius.UnitTests.TimeSeries.Client
{
    [TestFixture]
    public class AquariusClientTests
    {
        private AquariusClient _client;
        private IServiceClient _mockPublish;
        private IServiceClient _mockAcquisition;
        private IServiceClient _mockProvisioning;

        [SetUp]
        public void BeforeEachTest()
        {
            SetupClientWithMockEndpoints();
        }

        private void SetupClientWithMockEndpoints()
        {
            _client = new AquariusClient
            {
                ServerVersion = CreateDeveloperBuild(),
                SessionToken = "some token"
            };

            _mockPublish = CreateMockServiceClient();
            _mockAcquisition = CreateMockServiceClient();
            _mockProvisioning = CreateMockServiceClient();

            _client._serviceClients.Add(AquariusClient.ClientType.PublishJson, _mockPublish);
            _client._serviceClients.Add(AquariusClient.ClientType.AcquisitionJson, _mockAcquisition);
            _client._serviceClients.Add(AquariusClient.ClientType.ProvisioningJson, _mockProvisioning);
        }

        private AquariusServerVersion CreateDeveloperBuild()
        {
            return AquariusServerVersion.Create("0");
        }

        private IServiceClient CreateMockServiceClient()
        {
            var mockServiceClient = Substitute.For<IServiceClient>();

            return mockServiceClient;
        }

        [Test]
        public void Dispose_WithNgConnection_CallDeleteSession()
        {
            _client.Dispose();

            AssertExpectedDeleteSessionRequests(1);
        }

        private void AssertExpectedDeleteSessionRequests(int count)
        {
            _mockPublish
                .Received(count)
                .Delete(Arg.Any<DeleteSession>());
        }

        [Test]
        public void Dispose_With3xConnection_DoesNotCallDeleteSession()
        {
            _client.ServerVersion = AquariusServerVersion.Create("3.10");

            _client.Dispose();

            AssertExpectedDeleteSessionRequests(0);
        }
    }
}
