using Aquarius.Helpers;
using FluentAssertions;
using NUnit.Framework;
using ServiceStack;

namespace Aquarius.UnitTests.Helpers
{
    [TestFixture]
    public class SdkServiceClientTests
    {
        [Test]
        public void DefaulyCtor_IncludesExpectedUserAgent()
        {
            AssertJsonServiceClientHasExpectedUserAgent(new SdkServiceClient());
        }

        private void AssertJsonServiceClientHasExpectedUserAgent(JsonServiceClient client)
        {
            var userAgent = client.UserAgent;

            userAgent.Should().StartWith("ServiceStack");
            userAgent.Should().Contain("/" + UserAgentBuilder.GetSdkComponent());
            userAgent.Should().Contain("/" + UserAgentBuilder.GetApplicationComponent());
        }

        [Test]
        public void CtorWithUri_IncludesExpectedUserAgent()
        {
            AssertJsonServiceClientHasExpectedUserAgent(new SdkServiceClient("/api"));
        }
    }
}
