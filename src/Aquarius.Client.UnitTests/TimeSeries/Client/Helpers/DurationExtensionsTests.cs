using System;
using System.Collections.Generic;
using Aquarius.Client.UnitTests.TestHelpers;
using Aquarius.TimeSeries.Client.Helpers;
using FluentAssertions;
using NodaTime;
using NUnit.Framework;

namespace Aquarius.UnitTests.TimeSeries.Client.Helpers
{
    [TestFixture]
    public class DurationExtesionsTests
    {
        private static readonly IEnumerable<string> InvalidDurationStrings = new[]
        {
            "not a period",
            "13:03:05",
            "+-P1D",
            "-P1H"
        };

        private static readonly IEnumerable<TestCaseData> ValidDurationStringPairs = new[]
        {
            new TestCaseData("PT0S", Duration.Zero),
            new TestCaseData("P1D", NodaTimeHelpers.DurationFromDays(1)),
            new TestCaseData("-P1D", NodaTimeHelpers.DurationFromDays(-1)),
            new TestCaseData("P366D", NodaTimeHelpers.DurationFromDays(366)),
            new TestCaseData("PT1H", Duration.FromHours(1)),
            new TestCaseData("-PT1H", Duration.FromHours(-1)),
            new TestCaseData("PT1M", Duration.FromMinutes(1)),
            new TestCaseData("-PT1M", Duration.FromMinutes(-1)),
            new TestCaseData("PT1S", Duration.FromSeconds(1)),
            new TestCaseData("-PT1S", Duration.FromSeconds(-1)),
            new TestCaseData("P3DT5H", NodaTimeHelpers.DurationFromDays(3) + Duration.FromHours(5)),
            new TestCaseData("P3DT5M", NodaTimeHelpers.DurationFromDays(3) + Duration.FromMinutes(5)),
            new TestCaseData("P3DT5S", NodaTimeHelpers.DurationFromDays(3) + Duration.FromSeconds(5)),
            new TestCaseData("P2DT3H5M8S", NodaTimeHelpers.DurationFromDays(2) + Duration.FromHours(3) + Duration.FromMinutes(5) + Duration.FromSeconds(8)),
            new TestCaseData("-P2DT3H5M8S", -(NodaTimeHelpers.DurationFromDays(2) + Duration.FromHours(3) + Duration.FromMinutes(5) + Duration.FromSeconds(8))),
            new TestCaseData("PT3H5M8S", Duration.FromHours(3) + Duration.FromMinutes(5) + Duration.FromSeconds(8)),
            new TestCaseData("-PT3H5M8S", -(Duration.FromHours(3) + Duration.FromMinutes(5) + Duration.FromSeconds(8))),
            new TestCaseData("-PT2.718S", Duration.FromMilliseconds(-2718)),
            new TestCaseData("-PT2.7182818S", Duration.FromTicks(-27182818)),
            new TestCaseData("MINDURATION", Duration.FromTicks(Int64.MinValue)),
            new TestCaseData("MinDuration", Duration.FromTicks(Int64.MinValue)),
            new TestCaseData("minduration", Duration.FromTicks(Int64.MinValue)),
            new TestCaseData("MAXDURATION", Duration.FromTicks(Int64.MaxValue)),
            new TestCaseData("MaxDuration", Duration.FromTicks(Int64.MaxValue)),
            new TestCaseData("maxduration", Duration.FromTicks(Int64.MaxValue)),
        };

        [TestCaseSource("InvalidDurationStrings")]
        public void ParseDuration_GivenInvalidDuration_ReturnsNull(string invalidDuration)
        {
            Action parseDuration = () => invalidDuration.ParseDuration();

            parseDuration.ShouldThrow<FormatException>();
        }

        [TestCaseSource("ValidDurationStringPairs")]
        public void ParseDuration_GivenValidDurationStrings_ReturnsDuration(string validDuration, Duration expected)
        {
            var actual = validDuration.ParseDuration();

            Assert.That(actual, Is.EqualTo(expected));
        }

        [TestCaseSource("ValidDurationStringPairs")]
        public void SerializeToString_GivenValidDurationStrings_ReturnsExpectedString(string expected, Duration duration)
        {
            var actual = duration.SerializeToString();

            Assert.That(StringComparer.InvariantCultureIgnoreCase.Equals(actual, expected), Is.True);
        }

        [TestCaseSource("ValidDurationStringPairs")]
        public void SerializeToQuotedString_GivenValidDurationStrings_ReturnsQuotedString(string expected, Duration duration)
        {
            var actual = duration.SerializeToQuotedString();

            var expectedQuoted = '"' + expected + '"';
            Assert.That(StringComparer.InvariantCultureIgnoreCase.Equals(actual, expectedQuoted), Is.True);
        }
    }
}
