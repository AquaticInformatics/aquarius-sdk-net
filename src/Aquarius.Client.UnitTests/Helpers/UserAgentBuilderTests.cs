using System.IO;
using Aquarius.Helpers;
using FluentAssertions;
using NUnit.Framework;

namespace Aquarius.UnitTests.Helpers
{
    [TestFixture]
    public class UserAgentBuilderTests
    {
        [Test]
        public void GetSdkComponent_ShouldContainSdkAssemblyName()
        {
            var expected = Path.GetFileNameWithoutExtension(typeof(SdkServiceClient).Assembly.Location);
            var actual = UserAgentBuilder.GetSdkComponent();

            actual.Should().StartWith(expected);
        }

        [Test]
        public void GetApplicationComponent_ShouldNotBeEmpty()
        {
            var actual = UserAgentBuilder.GetApplicationComponent();

            actual.Should().NotBeEmpty();
        }
    }
}
