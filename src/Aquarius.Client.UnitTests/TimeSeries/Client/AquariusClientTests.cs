using System.Collections.Generic;
using Aquarius.TimeSeries.Client;
using Aquarius.TimeSeries.Client.ServiceModels.Provisioning;
using FluentAssertions;
using NSubstitute;
using NUnit.Framework;
using ServiceStack;
using DeleteSession = Aquarius.TimeSeries.Client.ServiceModels.Publish.DeleteSession;

#if AUTOFIXTURE4
using AutoFixture;
#else
using Ploeh.AutoFixture;
#endif

namespace Aquarius.Client.UnitTests.TimeSeries.Client
{
    [TestFixture]
    public class AquariusClientTests
    {
        private IFixture _fixture;
        private AquariusClient _client;
        private IServiceClient _mockPublish;
        private IServiceClient _mockAcquisition;
        private IServiceClient _mockProvisioning;
        private IAuthenticator _mockAuthenticator;

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
            _mockAuthenticator = CreateMockAuthenticator();

            _client.ServiceClients.Add(AquariusClient.ClientType.PublishJson, _mockPublish);
            _client.ServiceClients.Add(AquariusClient.ClientType.AcquisitionJson, _mockAcquisition);
            _client.ServiceClients.Add(AquariusClient.ClientType.ProvisioningJson, _mockProvisioning);

            _client.Connection = new Connection(
                _fixture.Create<string>(),
                _fixture.Create<string>(),
                _fixture.Create<string>(),
                _mockAuthenticator,
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

        private IAuthenticator CreateMockAuthenticator()
        {
            var mockAuthenticator = Substitute.For<IAuthenticator>();

            return mockAuthenticator;
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
