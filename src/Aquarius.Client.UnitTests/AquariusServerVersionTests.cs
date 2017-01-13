using System;
using System.Collections.Generic;
using FluentAssertions;
using NUnit.Framework;

namespace Aquarius.Client.UnitTests
{
    [TestFixture]
    public class AquariusServerVersionTests
    {
        [Test]
        public void Create_WithNullVersion_Throws()
        {
            Action action = () => AquariusServerVersion.Create(null);

            action.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void Create_WithEmptyVersion_Throws()
        {
            Action action = () => AquariusServerVersion.Create(string.Empty);

            action.ShouldThrow<FormatException>();
        }

        [Test]
        public void Create_WithNegativeVersion_Throws()
        {
            Action action = () => AquariusServerVersion.Create("123.-123");

            action.ShouldThrow<OverflowException>();
        }

        private static readonly IEnumerable<TestCaseData> SanitizeMajorVersionTests = new[]
        {
            new TestCaseData("Developer version", "0.0.0.0", "0.0.0.0"),
            new TestCaseData("Early 3X version", "3.6.121", "3.6.121"),
            new TestCaseData("Early NG version", "14.4.58", "2014.4.58"),
        };

        [TestCaseSource("SanitizeMajorVersionTests")]
        public void ToString_SanitizesMajorVersion(string reason, string apiVersion, string expected)
        {
            var version = AquariusServerVersion.Create(apiVersion);

            var actual = version.ToString();
            actual.ShouldBeEquivalentTo(expected, reason);

            var version2 = AquariusServerVersion.Create(expected);
            var actualCompare = version.Compare(version2);

            actualCompare.ShouldBeEquivalentTo(0, "Equivalent version.ToString() should also compare equally: {0}", reason);
        }

        private static readonly IEnumerable<TestCaseData> VersionComparisonTests = new[]
        {
            new TestCaseData("Same developer version", "0.0.0.0", "0.0.0.0", false, 0),
            new TestCaseData("Developer version is always considered newer than a real version", "0.0.0.0", "15", false, 1),
            new TestCaseData("Real version is always considered earlier than a developer version", "15", "0.0.0.0", true, -1),
            new TestCaseData("More components is always greater", "2", "2.1", true, -1),
            new TestCaseData("3X is less than NG", "3.9.123", "15.4.123", true, -1),
            new TestCaseData("NG is greater than NG", "15.4.123", "3.9.123", false, 1),
            new TestCaseData("PreviousYear.Last is less than NextYear.First", "15.4.123", "16.1.123", true, -1),
            new TestCaseData("NextYear.First is greater than PreviousYear.Last", "16.1.123", "15.4.123", false, 1),
            new TestCaseData("Simplest 3X version test is less than NG", "3", "15.4.123", true, -1),
            new TestCaseData("Simplest NG version test is greater than 3X", "15.4.123", "3", false, 1),
        };

        [TestCaseSource("VersionComparisonTests")]
        public void Compare_VersionsCompareAsExpected(string reason, string versionText1, string versionText2, bool expectedIs1LessThan2, int expectedCompare1With2)
        {
            expectedIs1LessThan2.ShouldBeEquivalentTo(expectedCompare1With2 < 0, "Test expectations are not self-consistent");

            var version1 = AquariusServerVersion.Create(versionText1);
            var version2 = AquariusServerVersion.Create(versionText2);

            var actualIs1LessThan2 = version1.IsLessThan(version2);
            actualIs1LessThan2.ShouldBeEquivalentTo(expectedIs1LessThan2, reason);

            var actualCompare1With2 = version1.Compare(version2);
            actualCompare1With2.ShouldBeEquivalentTo(expectedCompare1With2, reason);

            if (expectedIs1LessThan2)
            {
                var actualCompare2With1 = version2.Compare(version1);

                actualCompare2With1.ShouldBeEquivalentTo(1, "ver1 < ver2 should imply that ver2 > ver1");
            }
        }

        private static readonly IEnumerable<TestCaseData> IsDeveloperBuildTests = new[]
        {
            new TestCaseData("Simplest developer build", "0", true),
            new TestCaseData("Common developer build", "0.0.0.0", true),
            new TestCaseData("Super early alpha", "0.1", false),
            new TestCaseData("Early 3.X build", "3.6", false),
            new TestCaseData("Early NG build", "14.4", false),
        };

        [TestCaseSource(nameof(IsDeveloperBuildTests))]
        public void IsDeveloperBuild_DetectsCorrectly(string reason, string versionText, bool expected)
        {
            var version = AquariusServerVersion.Create(versionText);
            var actual = version.IsDeveloperBuild();

            actual.ShouldBeEquivalentTo(expected, reason);
        }
    }
}
