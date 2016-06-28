using System;
using System.Collections.Generic;
using System.Net;
using FluentAssertions;
using NSubstitute;
using NSubstitute.ExceptionExtensions;
using NUnit.Framework;
using ServiceStack;

namespace Aquarius.Client.UnitTests
{
    [TestFixture]
    public class AquariusSystemDetectorTests
    {
        private const string DummyServerName = "notaserver";
        private const string SomeLegacyApiVersion = "3.10.123";

        private IServiceClient _mockServiceClient;
        private AquariusSystemDetector _detector;

        [SetUp]
        public void ForEachTest()
        {
            _mockServiceClient = Substitute.For<IServiceClient>();
            _detector = new AquariusSystemDetector(s => _mockServiceClient);
        }

        private static readonly IEnumerable<TestCaseData> ValidApiVersions = new[]
        {
            new TestCaseData("0.0.0.0", AquariusServerType.NextGeneration, "Developer builds are always considered NG"),
            new TestCaseData("14.4", AquariusServerType.NextGeneration, "NG builds started with 14.4.x"),
            new TestCaseData("15.4", AquariusServerType.NextGeneration, "The first common NG build out in the wild"),
            new TestCaseData("16.1", AquariusServerType.NextGeneration, "The first NG build we expect to work well against"),
            new TestCaseData("3.6", AquariusServerType.Legacy3X, "The earliest supported server is AQAURIUS 3.6"),
            new TestCaseData("3.65535", AquariusServerType.Legacy3X, "Even the most horribly future 3.X build is still legacy"),
            new TestCaseData(SomeLegacyApiVersion, AquariusServerType.Legacy3X, "Other tests expect this version to be legacy"),
        };

        [TestCaseSource("ValidApiVersions")]
        public void GetAquariusServerType_ValidApiVersions_DetectsCorrectType(string apiVersion, AquariusServerType expected, string reason)
        {
            SetupMockToReturnApiVersion(apiVersion);

            var actual = _detector.GetAquariusServerType(DummyServerName);

            actual.ShouldBeEquivalentTo(expected, reason);
        }

        private void SetupMockToReturnApiVersion(string apiVersion)
        {
            _mockServiceClient
                .Get(Arg.Any<AquariusSystemDetector.GetVersion>())
                .ReturnsForAnyArgs(new AquariusSystemDetector.VersionResponse { ApiVersion = apiVersion });
        }

        [Test]
        public void GetAquariusServerType_ServiceClientThatThrows_ReportsUnknownOnFirstFailure()
        {
            SetupMockToThrow();

            var actual = _detector.GetAquariusServerType(DummyServerName);
            actual.ShouldBeEquivalentTo(AquariusServerType.Unknown);

            _mockServiceClient
                .Received(1)
                .Get(Arg.Any<AquariusSystemDetector.GetVersion>());
        }

        private void SetupMockToThrow()
        {
            _mockServiceClient
                .Get(Arg.Any<AquariusSystemDetector.GetVersion>())
                .ThrowsForAnyArgs(new Exception("oops"));
        }

        [Test]
        public void GetAquariusServerType_ServiceClientThatThrowsTimeoutException_ReportsUnknownAfterAllRetries()
        {
            SetupMockToThrowTimeoutException();

            var actual = _detector.GetAquariusServerType(DummyServerName);
            actual.ShouldBeEquivalentTo(AquariusServerType.Unknown);

            _mockServiceClient
                .Received(AquariusSystemDetector.MaximumRetryCount)
                .Get(Arg.Any<AquariusSystemDetector.GetVersion>());
        }

        private void SetupMockToThrowTimeoutException()
        {
            _mockServiceClient
                .Get(Arg.Any<AquariusSystemDetector.GetVersion>())
                .ThrowsForAnyArgs(new WebException("too slow", WebExceptionStatus.Timeout));
        }

        [Test]
        public void GetAquariusServerType_ServiceClientThatThrowsTimeoutExceptionAndThenSucceeds_ReportsExpectedType()
        {
            SetupMockToThrowOneTimeoutExceptionAndThenSucceed(SomeLegacyApiVersion);

            var actual = _detector.GetAquariusServerType(DummyServerName);
            actual.ShouldBeEquivalentTo(AquariusServerType.Legacy3X);

            _mockServiceClient
                .Received(2)
                .Get(Arg.Any<AquariusSystemDetector.GetVersion>());
        }

        private void SetupMockToThrowOneTimeoutExceptionAndThenSucceed(string apiVersion)
        {
            _mockServiceClient
                .Get(Arg.Any<AquariusSystemDetector.GetVersion>())
                .Returns(
                    x => { throw new WebException("too slow", WebExceptionStatus.Timeout); },
                    x => new AquariusSystemDetector.VersionResponse {ApiVersion = apiVersion}
                );
        }

        [Test]
        public void GetAquariusServerType_SameServerQueriedTwice_ReturnsCachedResult()
        {
            SetupMockToReturnApiVersion(SomeLegacyApiVersion);

            var actual1 = _detector.GetAquariusServerType(DummyServerName);
            var actual2 = _detector.GetAquariusServerType(DummyServerName);

            actual1.ShouldBeEquivalentTo(AquariusServerType.Legacy3X);
            actual1.ShouldBeEquivalentTo(actual2, "Two results should match");

            AssertServiceClientCallsReceived(1);
        }

        private void AssertServiceClientCallsReceived(int requiredNumberOfCalls)
        {
            _mockServiceClient
                .Received(requiredNumberOfCalls)
                .Get(Arg.Any<AquariusSystemDetector.GetVersion>());
        }

        [Test]
        public void GetAquariusServerType_UnknownValues_AreNotCached()
        {
            SetupMockForTwoCallsWhereFirstCallThrows();

            var actual1 = _detector.GetAquariusServerType(DummyServerName);
            actual1.ShouldBeEquivalentTo(AquariusServerType.Unknown);

            var actual2 = _detector.GetAquariusServerType(DummyServerName);
            actual2.ShouldBeEquivalentTo(AquariusServerType.Legacy3X);

            AssertServiceClientCallsReceived(2);
        }

        private void SetupMockForTwoCallsWhereFirstCallThrows()
        {
            _mockServiceClient
                .Get(Arg.Any<AquariusSystemDetector.GetVersion>())
                .Returns(x => { throw new Exception("oops"); }, x => new AquariusSystemDetector.VersionResponse { ApiVersion = SomeLegacyApiVersion });            
        }
    }
}
