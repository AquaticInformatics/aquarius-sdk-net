using System;
using System.Collections.Generic;
using Aquarius.TimeSeries.Client.Helpers;
using Aquarius.UnitTests.TimeSeries.Client.TestHelpers;
using FluentAssertions;
using NodaTime;
using NUnit.Framework;

#if AUTOFIXTURE4
using AutoFixture;
#else
using Ploeh.AutoFixture;
#endif

namespace Aquarius.UnitTests.TimeSeries.Client.Helpers
{
    [TestFixture]
    public class NodaTimeConverterTests
    {
        private static readonly DateTime MinDateTimeUtc = NodaTimeConverter.MinDateTimeUtc;
        private static readonly DateTime MaxDateTimeUtc = NodaTimeConverter.MaxDateTimeUtc;

        private static readonly Instant MinDateTimeInstant = NodaTimeConverter.MinDateTimeInstant;
        private static readonly Instant MaxDateTimeInstant = NodaTimeConverter.MaxDateTimeInstant;

        private static readonly DateTime DateTimeUtc0101 = new DateTime(2000, 01, 01, 0, 0, 0, DateTimeKind.Utc);
        private static readonly Instant Instant0101 = Instant.FromDateTimeUtc(DateTimeUtc0101);

        private IFixture _fixture;

        [SetUp]
        public void InitializeBeforeEachTest()
        {
            _fixture = new Fixture();
            NodaTimeFixtureRegistrar.RegisterNodaTimeTypes(_fixture);
        }

        [Test]
        public void ToDateTimeUtc_ConvertsMinInstantToMinDateTimeUtc()
        {
            Assert.That(NodaTimeConverter.ToDateTimeUtc(Instant.MinValue), Is.EqualTo(MinDateTimeUtc));
        }

        [Test]
        public void ToDateTimeUtc_ConvertsMaxInstantToMaxDateTimeUtc()
        {
            Assert.That(NodaTimeConverter.ToDateTimeUtc(Instant.MaxValue), Is.EqualTo(MaxDateTimeUtc));
        }

        private static readonly Instant[] _nonConvertibleInstants =
        {
            MinDateTimeInstant,
            MaxDateTimeInstant,
#if NODATIME1
            // NodaTime 2.x doesn't allow you construct out-of-range instants
            MinDateTimeInstant.Minus(Duration.FromSeconds(1)),
            MaxDateTimeInstant.Plus(Duration.FromSeconds(1))
#endif
        };

        [TestCaseSource("_nonConvertibleInstants")]
        public void ToDateTimeUtc_WithValuesOutsideOfRange_Throws(Instant input)
        {
            Assert.That(() => NodaTimeConverter.ToDateTimeUtc(input), Throws.TypeOf<ArgumentOutOfRangeException>());
        }

        private static  readonly Instant[] _twoWayConvertibleInstants =
        {
            Instant.FromUtc(2000, 01, 01, 00, 00),
            Instant.MinValue,
            Instant.MaxValue,
            MinDateTimeInstant.Plus(Duration.FromTicks(1)),
            MaxDateTimeInstant.Minus(Duration.FromTicks(1))
        };

        [TestCaseSource("_twoWayConvertibleInstants")]
        public void ToDateTimeUtc_ThenToInstant_ReturnsSameValue(Instant expected)
        {
            var dateTime = NodaTimeConverter.ToDateTimeUtc(expected);
            var actual = NodaTimeConverter.UtcDateTimeToInstant(dateTime);

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void ToDateTimeOffsetUtc_ReturnsExpectedValueWithOffsetZero()
        {
            var expected = new DateTimeOffset(2001, 01, 02, 03, 04, 05, TimeSpan.FromHours(-8));
            var instant = Instant.FromDateTimeOffset(expected);

            var actual = NodaTimeConverter.InstantToDateTimeOffsetUtc(instant);

            Assert.That(actual, Is.EqualTo(expected));
            Assert.That(actual.Offset, Is.EqualTo(TimeSpan.Zero));
        }

        [Test]
        public void UtcDateTimeAllowingUnspecifiedKindToInstant_WithUnspecifiedDateTimeKind_IsTreatedAsUtc()
        {
            var input = new DateTime(2000, 01, 01, 00, 00, 00, DateTimeKind.Unspecified);

            var output = NodaTimeConverter.UtcDateTimeAllowingUnspecifiedKindToInstant(input);

            Assert.That(output.ToDateTimeUtc(), Is.EqualTo(input));
        }

        [Test]
        public void NullableUtcDateTimeToDefaultBeginningOfTimeInstant_WithNull_ReturnsMinInstant()
        {
            var output = NodaTimeConverter.NullableUtcDateTimeToDefaultBeginningOfTimeInstant(null);

            Assert.That(output, Is.EqualTo(Instant.MinValue));
        }

        [Test]
        public void NullableUtcDateTimeToDefaultEndOfTimeInstant_WithNull_ReturnsMaxInstant()
        {
            var output = NodaTimeConverter.NullableUtcDateTimeToDefaultEndOfTimeInstant(null);

            Assert.That(output, Is.EqualTo(Instant.MaxValue));
        }

        [Test]
        public void ToDateTimeUtc_ConvertsDateTimeCorrectly()
        {
            Assert.That(NodaTimeConverter.ToDateTimeUtc(Instant0101), Is.EqualTo(DateTimeUtc0101));
        }

        [Test]
        public void UtcDateTimeToInstant_ConvertsMinDateTimeUtcToInstantMinValue()
        {
            Assert.That(NodaTimeConverter.UtcDateTimeToInstant(MinDateTimeUtc), Is.EqualTo(Instant.MinValue));
        }

        [Test]
        public void UtcDateTimeToInstant_ConvertsMaxDateTimeUtcToInstantMaxValue()
        {
            Assert.That(NodaTimeConverter.UtcDateTimeToInstant(MaxDateTimeUtc), Is.EqualTo(Instant.MaxValue));
        }

        [Test]
        public void UtcDateTimeToInstant_ThrowsIfDateTimeIsNotUtcKind()
        {
            var dateTime = new DateTime(2001, 01, 02);

            Assert.That(() => NodaTimeConverter.UtcDateTimeToInstant(dateTime), Throws.TypeOf<ArgumentException>());
        }

        [Test]
        public void HoursToOffsetPassedValueLessThanMinimumAllowedOffsetThrows()
        {
            const double utcOffsetLessThanMinimum = -13.0;

            TestDelegate testDelegate = () => NodaTimeConverter.HoursToOffset(utcOffsetLessThanMinimum);

            Assert.That(testDelegate, Throws.TypeOf<ArgumentOutOfRangeException>());
        }

        [Test]
        public void NullableUtcDateTimeToNullableInstant_GivenNull_ReturnsNull()
        {
            var result = NodaTimeConverter.NullableUtcDateTimeToNullableInstant(null);

            Assert.That(result, Is.Null);
        }

        [Test]
        public void HoursToOffsetPassedValueGreaterThanMaximumAllowedOffsetThrows()
        {
            const double utcOffsetGreaterThanMaximum = 15.0;

            TestDelegate testDelegate = () => NodaTimeConverter.HoursToOffset(utcOffsetGreaterThanMaximum);

            Assert.That(testDelegate, Throws.TypeOf<ArgumentOutOfRangeException>());
        }

        [Test]
        public void OffsetToHours_WithOffsetLessThanAllowedMinimum_Throws()
        {
            var offsetLessThanAllowedMinimum = Offset.FromHours(-15);

            Action action = () => NodaTimeConverter.OffsetToHours(offsetLessThanAllowedMinimum);

            action.ShouldThrow<ArgumentOutOfRangeException>();
        }

        [Test]
        public void OffsetToHours_WithOffsetGreaterThanAllowedMaximum_Throws()
        {
            var offsetGreaterThanAllowedMaximum = Offset.FromHours(15);

            Action action = () => NodaTimeConverter.OffsetToHours(offsetGreaterThanAllowedMaximum);

            action.ShouldThrow<ArgumentOutOfRangeException>();
        }

        [TestCaseSource("OffsetsWithinAllowedRange")]
        public void OffsetToHours_WithValueInAllowedRange_ConvertsCorrectly(double expectedUtcOffsetInHours, long offsetInTicks)
        {
            var offset = Offset.FromTicks(offsetInTicks);

            var actual = NodaTimeConverter.OffsetToHours(offset);

            actual.ShouldBeEquivalentTo(expectedUtcOffsetInHours);
        }

        private static readonly IEnumerable<TestCaseData> OffsetsWithinAllowedRange = new[]
        {
            new TestCaseData(-12.0, -432000000000),
            new TestCaseData(-8.0, -288000000000),
            new TestCaseData(0, 0),
            new TestCaseData(14, 504000000000),
        };

        [TestCaseSource("OffsetsWithinAllowedRange")]
        public void HoursToOffsetPassedValueWithinAllowedRangeReturnsCorrectResult(double testUtcOffset, long expectedResultInTicks)
        {
            var result = NodaTimeConverter.HoursToOffset(testUtcOffset);

            Assert.That(result, Is.EqualTo(Offset.FromTicks(expectedResultInTicks)));
        }

        private static readonly IEnumerable<TestCaseData> _validIso8601Cases =
            new List<TestCaseData>
            {
                new TestCaseData("MinInstant", Instant.MinValue),
                new TestCaseData("MaxInstant", Instant.MaxValue),
                new TestCaseData("2000-11-29T18:43:17Z", Instant.FromUtc(2000, 11, 29, 18, 43, 17)),
                new TestCaseData("2000-11-29T18:43:17.013Z", Instant.FromUtc(2000, 11, 29, 18, 43, 17) + Duration.FromMilliseconds(13)),
                new TestCaseData("2000-11-29T18:43:17.0130173Z", Instant.FromUtc(2000, 11, 29, 18, 43, 17) + Duration.FromTicks(130173)),
                new TestCaseData("2000-11-29T18:43:17.013+05:00", Instant.FromUtc(2000, 11, 29, 13, 43, 17) + Duration.FromMilliseconds(13)),
                new TestCaseData("2000-11-29T18:43:17.013-08:00", Instant.FromUtc(2000, 11, 30, 2, 43, 17) + Duration.FromMilliseconds(13)),
                new TestCaseData("2000-11-29T18:43:17.13-08:00", Instant.FromUtc(2000, 11, 30, 2, 43, 17) + Duration.FromMilliseconds(130)),
                new TestCaseData("2000-11-29T18:43:17.013+00:00", Instant.FromUtc(2000, 11, 29, 18, 43, 17) + Duration.FromMilliseconds(13)),
                new TestCaseData("2000-11-29T18:43:17.013-00:00", Instant.FromUtc(2000, 11, 29, 18, 43, 17) + Duration.FromMilliseconds(13)),
                new TestCaseData("2000-11-29T24:00:00.000-11:00", Instant.FromUtc(2000, 11, 30, 11, 0, 0)),
                new TestCaseData("2000-11-29T24:00:00.000Z", Instant.FromUtc(2000, 11, 30, 0, 0, 0)),
            };

        [TestCaseSource("_validIso8601Cases")]
        public void Iso8601ToInstantPassedValidValueReturnsCorrectResult(string testValue, Instant expectedValue)
        {
            var result = NodaTimeConverter.Iso8601ToInstant(testValue,
                Iso8601ParseOptions.AllowBeginningOfTime | Iso8601ParseOptions.AllowEndOfTime);

            Assert.That(result, Is.EqualTo(expectedValue));
        }

        private static readonly IEnumerable<TestCaseData> _invalidIso8601Cases =
            new List<TestCaseData>
            {
                new TestCaseData("MinimumInstant", Iso8601ParseOptions.AllowBeginningOfTime),
                new TestCaseData("MaximumInstant", Iso8601ParseOptions.AllowEndOfTime),
                new TestCaseData("2000-11-29T18:43:17.013", Iso8601ParseOptions.None),
                new TestCaseData("2000-11-29T18:43:17.013+25:00", Iso8601ParseOptions.None),
                new TestCaseData("2000-11-29T18:43:17.013-27:00", Iso8601ParseOptions.None),
                new TestCaseData("2000-11-29T18:43:17.013Z ", Iso8601ParseOptions.None),
                new TestCaseData("MinInstant", Iso8601ParseOptions.None),
                new TestCaseData("MaxInstant", Iso8601ParseOptions.None),
            };

        [TestCaseSource("_invalidIso8601Cases")]
        public void Iso8601ToInstantPassedInvalidValueThrowsArgumentException(string testValue, Iso8601ParseOptions options)
        {
            Assert.That(() => NodaTimeConverter.Iso8601ToInstant(testValue, options), Throws.ArgumentException);
        }

        [Test]
        public void ToNullableDateTimeUtc_MinValue_ConvertsToNull()
        {
            var dateTimeUtc = NodaTimeConverter.ToNullableDateTimeUtc(Instant.MinValue);

            dateTimeUtc.ShouldBeEquivalentTo(null);
        }

        [Test]
        public void ToNullableDateTimeUtc_MaxValue_ConvertsToNull()
        {
            var dateTimeUtc = NodaTimeConverter.ToNullableDateTimeUtc(Instant.MaxValue);

            dateTimeUtc.ShouldBeEquivalentTo(null);
        }

        [TestCaseSource("_nonConvertibleInstants")]
        public void ToNullableDateTimeUtc_ValuesOutsideOfRange_Throws(Instant input)
        {
            Action action = () => NodaTimeConverter.ToNullableDateTimeUtc(input);

            action.ShouldThrow<ArgumentOutOfRangeException>();
        }

        [Test]
        public void ToNullableDateTimeUtc_ConvertToDateTimeCorrectly()
        {
            var dateTimeUtc = NodaTimeConverter.ToNullableDateTimeUtc(Instant0101);

            dateTimeUtc.ShouldBeEquivalentTo(DateTimeUtc0101);
        }

        [Test]
        public void ToNullableDateTimeUtc_NullInstant_ConvertsToNullDateTime()
        {
            var dateTimeUtc = NodaTimeConverter.ToNullableDateTimeUtc(null);

            dateTimeUtc.ShouldBeEquivalentTo(null);
        }

        [TestCaseSource("OffsetValues")]
        public void ToOffsetDateTime_GivenMinValue_ReturnsOffsetDateTime_WithMinInstantValue(Offset offset)
        {
            var minOffsetDateTime = NodaTimeConverter.ToOffsetDateTime(Instant.MinValue, offset);

            minOffsetDateTime.ToInstant().Should().Be(Instant.MinValue);
        }

        private static readonly IEnumerable<Offset> OffsetValues = new[]
        {
            Offset.FromHours(-12),
            Offset.FromHoursAndMinutes(-4, 30),
            Offset.Zero,
            Offset.FromHoursAndMinutes(5, 45),
            Offset.FromHours(14)
        };

        [TestCaseSource("OffsetValues")]
        public void ToOffsetDateTime_GivenMinValue_ReturnsMinOffsetDateTime(Offset offset)
        {
            var minOffsetDateTime = NodaTimeConverter.ToOffsetDateTime(Instant.MinValue, offset);

            minOffsetDateTime.Should().Be(NodaTimeConverter.MinOffsetDateTime);
        }

        [TestCaseSource("OffsetValues")]
        public void ToOffsetDateTime_GivenMaxValue_ReturnsOffsetDateTime_WithMaxInstantValue(Offset offset)
        {
            var maxOffsetDateTime = NodaTimeConverter.ToOffsetDateTime(Instant.MaxValue, offset);

            maxOffsetDateTime.ToInstant().Should().Be(Instant.MaxValue);
        }

        [TestCaseSource("OffsetValues")]
        public void ToOffsetDateTime_GivenMaxValue_ReturnsMaxOffsetDateTime(Offset offset)
        {
            var maxOffsetDateTime = NodaTimeConverter.ToOffsetDateTime(Instant.MaxValue, offset);

            maxOffsetDateTime.Should().Be(NodaTimeConverter.MaxOffsetDateTime);
        }

        [TestCaseSource("OffsetValues")]
        public void ToOffsetDateTime_GivenInstant_ReturnsExpected(Offset offset)
        {
            var time = _fixture.Create<Instant>();

            var offsetDateTime = NodaTimeConverter.ToOffsetDateTime(time, offset);

            offsetDateTime.ToInstant().Should().Be(time);
            offsetDateTime.Offset.Should().Be(offset);
        }

        [Test]
        public void ToDateTimeOffset_GivenMinOffsetDateTime_ReturnsDateTimeOffsetMinValue()
        {
            var minOffsetDateTime = NodaTimeConverter.MinOffsetDateTime;

            var minDateTimeOffset = NodaTimeConverter.ToDateTimeOffset(minOffsetDateTime);

            minDateTimeOffset.DateTime.Should().Be(NodaTimeConverter.MinDateTimeUtc);
            minDateTimeOffset.Should().Be(DateTimeOffset.MinValue);
        }

        [Test]
        public void ToDateTimeOffset_GivenMinDateTimeInstant_WithZeroOffset_Throws()
        {
            var minDateTimeInstant = NodaTimeConverter.MinDateTimeInstant;
            var offsetDateTimeWithMinInstant = NodaTimeConverter.ToOffsetDateTime(minDateTimeInstant, Offset.Zero);

            Action toDateTimeOffset = () => NodaTimeConverter.ToDateTimeOffset(offsetDateTimeWithMinInstant);

            toDateTimeOffset.ShouldThrow<ArgumentOutOfRangeException>();
        }

        [Test]
        public void ToDateTimeOffset_GivenMaxOffsetDateTime_ReturnsDateTimeOffsetMaxValue()
        {
            var maxOffsetDateTime = NodaTimeConverter.MaxOffsetDateTime;

            var maxDateTimeOffset = NodaTimeConverter.ToDateTimeOffset(maxOffsetDateTime);

            maxDateTimeOffset.DateTime.Should().Be(NodaTimeConverter.MaxDateTimeUtc);
            maxDateTimeOffset.Should().Be(DateTimeOffset.MaxValue);
        }

        [Test]
        public void ToDateTimeOffset_GivenMaxDateTimeInstant_WithZeroOffset_Throws()
        {
            var maxDateTimeInstant = NodaTimeConverter.MaxDateTimeInstant;
            var offsetDateTimeWithMaxInstant = NodaTimeConverter.ToOffsetDateTime(maxDateTimeInstant, Offset.Zero);

            Action toDateTimeOffset = () => NodaTimeConverter.ToDateTimeOffset(offsetDateTimeWithMaxInstant);

            toDateTimeOffset.ShouldThrow<ArgumentOutOfRangeException>();
        }

        [TestCaseSource("OffsetValues")]
        public void ToDateTimeOffset_GivenOffsetDateTime_ReturnsExpected(Offset offset)
        {
            var instant = _fixture.Create<Instant>();
            var offsetDateTime = instant.WithOffset(offset);

            var dateTimeOffset = NodaTimeConverter.ToDateTimeOffset(offsetDateTime);

            Instant.FromDateTimeOffset(dateTimeOffset).Should().Be(instant);
            Offset.FromTicks(dateTimeOffset.Offset.Ticks).Should().Be(offset);
        }

        [TestCaseSource("OffsetValues")]
        public void ToOffsetDateTime_AndToDateTimeOffset_ConvertsMinInstantToMinDateTimeOffset(Offset offset)
        {
            var offsetDateTime = NodaTimeConverter.ToOffsetDateTime(Instant.MinValue, offset);
            var dateTimeOffset = NodaTimeConverter.ToDateTimeOffset(offsetDateTime);

            dateTimeOffset.Should().Be(DateTimeOffset.MinValue);
        }

        [TestCaseSource("OffsetValues")]
        public void ToOffsetDateTime_AndToDateTimeOffset_ConvertsMaxInstantToMaxDateTimeOffset(Offset offset)
        {
            var offsetDateTime = NodaTimeConverter.ToOffsetDateTime(Instant.MaxValue, offset);
            var dateTimeOffset = NodaTimeConverter.ToDateTimeOffset(offsetDateTime);

            dateTimeOffset.Should().Be(DateTimeOffset.MaxValue);
        }
    }
}
