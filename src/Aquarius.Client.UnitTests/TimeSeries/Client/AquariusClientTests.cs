using System.Collections.Generic;
using Aquarius.TimeSeries.Client;
using Aquarius.TimeSeries.Client.ServiceModels.Provisioning;
using FluentAssertions;
using NSubstitute;
using NUnit.Framework;
using AutoFixture;
using ServiceStack;
using DeleteSession = Aquarius.TimeSeries.Client.ServiceModels.Publish.DeleteSession;

namespace Aquarius.UnitTests.TimeSeries.Client
{
    [TestFixture]
    public class AquariusClientTests
    {
        private IFixture _fixture;
        private AquariusClient _client;
        private IServiceClient _mockPublish;
        private IServiceClient _mockAcquisition;
        private IServiceClient _mockProvisioning;

        [SetUp]
        public void BeforeEachTest()
        {
            _fixture = new Fixture();

            SetupClientWithMockEndpoints();
        }

        private void SetupClientWithMockEndpoints()
        {
            _client = new AquariusClient
            {
                ServerVersion = CreateDeveloperBuild()
            };

            _mockPublish = CreateMockServiceClient();
            _mockAcquisition = CreateMockServiceClient();
            _mockProvisioning = CreateMockServiceClient();

            _client.ServiceClients.Add(AquariusClient.ClientType.PublishJson, _mockPublish);
            _client.ServiceClients.Add(AquariusClient.ClientType.AcquisitionJson, _mockAcquisition);
            _client.ServiceClients.Add(AquariusClient.ClientType.ProvisioningJson, _mockProvisioning);

            _client.Connection = new Connection(
                _fixture.Create<string>(),
                _fixture.Create<string>(),
                (username,password) => string.Join("/", username, password),
                _client.DeleteSession,
                connection => { });
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

        [Ignore("This integration test should only be run from within the IDE, connecting to a live AQTS app server")]
        [Test]
        public void IntegrationTest_SequentialConnectionsToTheSameServer_Succeed()
        {
            var u1 = GetUnitsFromALiveServer();
            var u2 = GetUnitsFromALiveServer();

            u1.ShouldBeEquivalentTo(u2);
        }

        private List<PopulatedUnitGroup> GetUnitsFromALiveServer()
        {
            using (var client = AquariusClient.CreateConnectedClient("doug-vm2012r2", "admin", "admin"))
            {
                return client.Provisioning.Get(new GetUnits()).Results;
            }
        }
    }
}
