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

        [Test]
        public void GetExecutingAssemblyPath_ReturnsAbsolutePath()
        {
            var path = UserAgentBuilder.GetExecutingAssemblyPath();

            Path.IsPathRooted(path).Should().BeTrue("assembly path should be an absolute path, not a URI or relative path");
        }

        [Test]
        public void GetExecutingAssemblyPath_ReturnsExistingFile()
        {
            var testAssemblyLocation = typeof(UserAgentBuilderTests).Assembly.Location;

            if (string.IsNullOrWhiteSpace(testAssemblyLocation))
            {
                Assert.Ignore("This assertion requires the test assembly to have a real file-system location. Some test hosts load assemblies without a meaningful Assembly.Location.");
            }

            var path = UserAgentBuilder.GetExecutingAssemblyPath();

            File.Exists(path).Should().BeTrue("assembly path should point to a real file on disk when the test host exposes a real assembly location");
        }

        [Test]
        public void GetExecutingAssemblyPath_DoesNotContainUriScheme()
        {
            var path = UserAgentBuilder.GetExecutingAssemblyPath();

            path.Should().NotStartWith("file://", "path should be a plain file path, not a URI");
        }
    }
}
