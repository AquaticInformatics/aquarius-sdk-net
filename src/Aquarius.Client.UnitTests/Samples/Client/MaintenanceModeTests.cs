using System;
using Aquarius.Samples.Client;
using Aquarius.Samples.Client.ServiceModel;
using NSubstitute;
using NUnit.Framework;
using ServiceStack;
using FluentAssertions;

#if AUTOFIXTURE4
using AutoFixture;
#else
using Ploeh.AutoFixture;
#endif

namespace Aquarius.Client.UnitTests.Samples.Client
{
    [TestFixture]
    public class MaintenanceModeTests
    {
        private IServiceClient _fakeServiceClient;
        private IFixture _fixture;

        [SetUp]
        public void ForEachTest()
        {
            _fakeServiceClient = Substitute.For<IServiceClient>();
            _fixture = new Fixture();
        }

        [Test]
        public void ClientDetectsMaintenanceModeOnCreation()
        {
            _fakeServiceClient
                .Get(Arg.Any<GetStatus>())
                .Returns(x =>
                {
                    throw new WebServiceException
                    {
                        StatusCode = 500
                    };
                });
            
            ((Action) (() => SamplesClient.CreateTestClient(_fakeServiceClient)))
                .ShouldThrow<SamplesMaintenanceModeException>();
        }

        [Test]
        public void ClientDetectsMaintenanceModeAfterCreation()
        {
            _fakeServiceClient
                .Get(Arg.Any<GetStatus>())
                .Returns(new Status { ReleaseName = "0.0" });

            _fakeServiceClient
                .Get(Arg.Any<SamplesClient.GetUserTokens>())
                .Returns(_fixture.Create<SamplesClient.UserTokensResponse>());
            
            var client = SamplesClient.CreateTestClient(_fakeServiceClient);
            PutFakeServiceClientInMaintenanceMode(_fakeServiceClient);

            ((Action)(() => client.Post(new PostTag())))
                .ShouldThrow<SamplesMaintenanceModeException>();
        }

        private void PutFakeServiceClientInMaintenanceMode(IServiceClient fakeServiceClient)
        {
            _fakeServiceClient
                .Post(Arg.Any<PostTag>())
                .Returns(x =>
                {
                    throw new WebServiceException
                    {
                        StatusCode = 500
                    };
                });
            
            _fakeServiceClient
                .Get(Arg.Any<GetStatus>())
                .Returns(x =>
                {
                    throw new WebServiceException
                    {
                        StatusCode = 500
                    };
                });
        }
    }
}