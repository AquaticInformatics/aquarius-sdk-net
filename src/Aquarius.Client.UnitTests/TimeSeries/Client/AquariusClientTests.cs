using System;
using System.Collections.Generic;
using System.Linq;
using Aquarius.Client.UnitTests.TestHelpers;
using Aquarius.Helpers;
using Aquarius.TimeSeries.Client;
using Aquarius.TimeSeries.Client.EndPoints;
using Aquarius.TimeSeries.Client.ServiceModels.Provisioning;
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

            var mockHost = "http://example.com";

            _client.AddServiceClient(AquariusClient.ClientType.PublishJson, _mockPublish, PublishV2.ResolveEndpoint(mockHost));
            _client.AddServiceClient(AquariusClient.ClientType.AcquisitionJson, _mockAcquisition, AcquisitionV2.ResolveEndpoint(mockHost));
            _client.AddServiceClient(AquariusClient.ClientType.ProvisioningJson, _mockProvisioning, Provisioning.ResolveEndpoint(mockHost));

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
            using (var client = AquariusClient.CreateConnectedClient("doug-vm2019", "admin", "admin"))
            {
                return client.Provisioning.Get(new GetUnits()).Results;
            }
        }

        [Test]
        public void Publish_HasBaseUri()
        {
            AssertClientHasBaseUri(_client.Publish);
        }

        [Test]
        public void Acquisition_HasBaseUri()
        {
            AssertClientHasBaseUri(_client.Acquisition);
        }

        [Test]
        public void Provisioning_HasBaseUri()
        {
            AssertClientHasBaseUri(_client.Provisioning);
        }

        private void AssertClientHasBaseUri(IServiceClient serviceClient)
        {
            var baseUri = _client.GetBaseUri(serviceClient);

            baseUri.Should().NotBeNullOrWhiteSpace();
        }

        [Test]
        public void UnregisteredServiceClient_HasNoBaseUri()
        {
            var otherClient = new JsonServiceClient();

            var baseUri = _client.GetBaseUri(otherClient);

            baseUri.Should().BeNullOrEmpty();
        }
    }
}
