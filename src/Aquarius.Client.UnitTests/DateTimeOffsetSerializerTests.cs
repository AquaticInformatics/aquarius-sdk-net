using System;
using System.Collections.Generic;
using System.Globalization;
using Aquarius.Client.ServiceModels.Publish;
using FluentAssertions;
using NUnit.Framework;

namespace Aquarius.Client.UnitTests
{
    [TestFixture]
    public class DateTimeOffsetSerializerTests
    {
        private static readonly DateTimeOffset Xmas      = new DateTimeOffset(2015, 12, 25, 0, 0, 0, TimeSpan.FromHours(-8));
        private static readonly DateTimeOffset BoxingDay = new DateTimeOffset(2015, 12, 26, 0, 0, 0, TimeSpan.FromHours(-8));

        private static readonly StatisticalDateTimeOffset XmasStart = new StatisticalDateTimeOffset { DateTimeOffset = Xmas, RepresentsEndOfTimePeriod = false };
        private static readonly StatisticalDateTimeOffset XmasEnd = new StatisticalDateTimeOffset { DateTimeOffset = BoxingDay, RepresentsEndOfTimePeriod = true };
        private static readonly StatisticalDateTimeOffset BoxingDayStart = new StatisticalDateTimeOffset { DateTimeOffset = BoxingDay, RepresentsEndOfTimePeriod = false };

        private static readonly IEnumerable<TestCaseData> SerializationTests = new[]
        {
            new TestCaseData("Xmas", XmasStart, Xmas.ToString("o", CultureInfo.InvariantCulture)),
            new TestCaseData("XmasEnd", XmasEnd, Xmas.ToString("o", CultureInfo.InvariantCulture).Replace("T00:", "T24:")),
            new TestCaseData("BoxingDay", BoxingDayStart, BoxingDay.ToString("o", CultureInfo.InvariantCulture)),
        };

        [TestCaseSource("SerializationTests")]
        public void StatisticalDateTimeOffset_RoundTripsCorrectly(string reason, StatisticalDateTimeOffset statisticalDateTimeOffset, string expectedJsonText)
        {
            var actualDateTimeOffset = DateTimeOffsetSerializer.DeserializeFromJsonLikeFormat(expectedJsonText);

            actualDateTimeOffset.ShouldBeEquivalentTo(statisticalDateTimeOffset, reason);

            var actualJsonText = DateTimeOffsetSerializer.SerializeToJsonLikeFormat(statisticalDateTimeOffset);

            actualJsonText.ShouldBeEquivalentTo(expectedJsonText, reason);
        }
    }
}
