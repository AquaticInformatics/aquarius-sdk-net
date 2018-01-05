using System;
using System.Collections.Generic;
using System.Globalization;
using Aquarius.TimeSeries.Client;
using Aquarius.TimeSeries.Client.Helpers;
using Aquarius.TimeSeries.Client.ServiceModels.Publish;
using FluentAssertions;
using NodaTime;
using NUnit.Framework;
using ServiceStack;
using ServiceStack.Text;
using static System.FormattableString;

namespace Aquarius.UnitTests.TimeSeries.Client
{
    class JsonSerializationTests
    {
        private static readonly DateTime ArbitraryUtcDate = new DateTime(1901, 02, 03, 04, 05, 06, DateTimeKind.Utc).AddMilliseconds(789);

        [OneTimeSetUp]
        public void BeforeAnyTests()
        {
            ServiceStackConfig.ConfigureServiceStack();
        }

        [Test]
        public void DateTime_SerializesToExpectedText()
        {
            var input = ArbitraryUtcDate;
            const string expected = "\"1901-02-03T04:05:06.789Z\"";

            var actual = input.ToJson();

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void DateTime_RoundTrip_ReturnsSameValue()
        {
            var input = new DateTime(1901, 02, 03, 04, 05, 06, DateTimeKind.Utc).AddMilliseconds(789);

            AssertRoundTripReturnsSameValue(input);
        }

        private static void AssertRoundTripReturnsSameValue(DateTime input)
        {
            var json = input.ToJson();
            var actual = json.FromJson<DateTime>();

            Assert.That(actual, Is.EqualTo(input), "Value");
            Assert.That(actual.Kind, Is.EqualTo(input.Kind), "Kind");
        }

        [Test]
        public void DateTime_RoundTripAndDateTimeWithTwoDecimalPoints_ReturnsSameValue()
        {
            var input = new DateTime(1901, 02, 03, 04, 05, 06, DateTimeKind.Utc).AddMilliseconds(110);

            AssertRoundTripReturnsSameValue(input);
        }

        [Test]
        public void DateTime_RoundTripWithOneTickPastMidnight_ReturnsSameValue()
        {
            var input = new DateTime(1901, 02, 03, 00, 00, 00, DateTimeKind.Utc).AddTicks(1);

            AssertRoundTripReturnsSameValue(input);
        }

        [Test]
        public void DateTime_UsingJsConfigThatOverridesDefaultIncludeNullValues_SerializesDefaultValue()
        {
            using (CreateJsConfigThatOverridesDefaultIncludeNullValuesSetting())
            {
                var defaultValue = default(DateTime);
                var expected = GetJsonForDtoWithValue("\"0001-01-01T00:00:00Z\"");

                var dto = new TestDto<DateTime> { Value = defaultValue };
                var actual = dto.ToJson();

                Assert.That(actual, Is.EqualTo(expected));
            }
        }

        private static JsConfigScope CreateJsConfigThatOverridesDefaultIncludeNullValuesSetting()
        {
            var jsConfig = JsConfig.BeginScope();
            jsConfig.IncludeNullValues = false;
            jsConfig.IncludeNullValuesInDictionaries = false;

            return jsConfig;
        }

        [Test]
        public void DateTime_UsingJsConfigThatOverridesDefaultIncludeNullValues_RoundTripsDefaultValue()
        {
            using (CreateJsConfigThatOverridesDefaultIncludeNullValuesSetting())
            {
                var expected = default(DateTime);
                var dto = new TestDto<DateTime> { Value = default(DateTime) };
                var serialized = dto.ToJson();
                var deserialized = serialized.FromJson<TestDto<DateTime>>();
                var actual = deserialized.Value;

                Assert.That(actual, Is.EqualTo(expected));
            }
        }

        public readonly object[][] ExpectedNodaTimeInstantJson =
        {
            new object[] {Instant.FromDateTimeUtc(ArbitraryUtcDate), "\"1901-02-03T04:05:06.789Z\""},
            new object[] {Instant.FromDateTimeUtc(ArbitraryUtcDate).PlusTicks(1), "\"1901-02-03T04:05:06.7890001Z\""},
            new object[] {Instant.MinValue, "\"MinInstant\""},
            new object[] {Instant.MaxValue, "\"MaxInstant\""}
        };

        [TestCaseSource(nameof(ExpectedNodaTimeInstantJson))]
        public void NodaTimeInstant_SerializesToExpectedText(Instant input, string expected)
        {
            var actual = input.ToJson();

            Assert.That(actual, Is.EqualTo(expected));
        }

        [TestCaseSource(nameof(ExpectedNodaTimeInstantJson))]
        public void NodaTimeInstant_RoundTrip_ReturnsSameValue(Instant input, string ignore)
        {
            var json = input.ToJson();
            var actual = json.FromJson<Instant>();

            Assert.That(actual, Is.EqualTo(input));
        }

        public readonly object[][] ExpectedJsonNodaTimeInstants =
        {
            new object[] {"\"1901-02-03T04:05:06.789Z\"", Instant.FromDateTimeUtc(ArbitraryUtcDate)},
            new object[] {"\"1901-02-03T08:05:06.789+04:00\"", Instant.FromDateTimeUtc(ArbitraryUtcDate)},
            new object[] {"\"1901-02-03T08:35:06.789+04:30\"", Instant.FromDateTimeUtc(ArbitraryUtcDate)},
            new object[] {"\"1901-02-03T08:35:06.7890001+04:30\"", Instant.FromDateTimeUtc(ArbitraryUtcDate).PlusTicks(1)},
            new object[] {"\"1901-02-03T00:00:00.0000001Z\"", Instant.FromDateTimeUtc(new DateTime(1901, 02, 03, 00, 00, 00, DateTimeKind.Utc)).PlusTicks(1)},
            new object[] {"\"MININSTANT\"", Instant.MinValue},
            new object[] {"\"minInStAnT\"", Instant.MinValue},
            new object[] {"\"MAXINSTANT\"", Instant.MaxValue},
            new object[] {"\"maxInStAnT\"", Instant.MaxValue}
        };

        [TestCaseSource(nameof(ExpectedJsonNodaTimeInstants))]
        public void NodaTimeInstant_ParsesVariousValues(string input, Instant expected)
        {
            var actual = input.FromJson<Instant>();

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void NodaTimeInstant_UsingJsConfigThatOverridesDefaultIncludeNullValues_SerializesDefaultValue()
        {
            using (CreateJsConfigThatOverridesDefaultIncludeNullValuesSetting())
            {
                var defaultValue = default(Instant);
                var expected = GetJsonForDtoWithValue("\"1970-01-01T00:00:00Z\"");

                var dto = new TestDto<Instant> { Value = defaultValue };
                var actual = dto.ToJson();

                Assert.That(actual, Is.EqualTo(expected));
            }
        }

        [Test]
        public void NodaTimeInstant_UsingJsConfigThatOverridesDefaultIncludeNullValues_RoundTripsDefaultValue()
        {
            using (CreateJsConfigThatOverridesDefaultIncludeNullValuesSetting())
            {
                var expected = default(Instant);
                var dto = new TestDto<Instant> { Value = default(Instant) };
                var serialized = dto.ToJson();
                var deserialized = serialized.FromJson<TestDto<Instant>>();
                var actual = deserialized.Value;

                Assert.That(actual, Is.EqualTo(expected));
            }
        }

        [Test]
        public void NodaTimeNullableInstant_UsingJsConfigThatOverridesDefaultIncludeNullValues_DoesNotSerializeDefaultValue()
        {
            using (CreateJsConfigThatOverridesDefaultIncludeNullValuesSetting())
            {
                const string expected = "{}";

                var dto = new TestDto<Instant?> { Value = default(Instant?) };
                var actual = dto.ToJson();

                Assert.That(actual, Is.EqualTo(expected));
            }
        }

        [Test]
        public void NodaTimeNullableInstant_UsingJsConfigThatOverridesDefaultIncludeNullValues_SerializesValueTypeDefaultValue()
        {
            using (CreateJsConfigThatOverridesDefaultIncludeNullValuesSetting())
            {
                var defaultValue = default(Instant);
                var expected = GetJsonForDtoWithValue("\"1970-01-01T00:00:00Z\"");

                var dto = new TestDto<Instant?> { Value = defaultValue };
                var actual = dto.ToJson();

                Assert.That(actual, Is.EqualTo(expected));
            }
        }

        [Test]
        public void NodaTimeNullableInstant_UsingJsConfigThatOverridesDefaultIncludeNullValues_RoundTripsDefaultValue()
        {
            using (CreateJsConfigThatOverridesDefaultIncludeNullValuesSetting())
            {
                var dto = new TestDto<Instant?> { Value = default(Instant?) };
                var serialized = dto.ToJson();
                var deserialized = serialized.FromJson<TestDto<Instant?>>();
                var actual = deserialized.Value;

                Assert.That(actual, Is.Null);
            }
        }

        [Test]
        public void NodaTimeNullableInstant_UsingJsConfigThatOverridesDefaultIncludeNullValues_RoundTripsValueTypeDefaultValue()
        {
            using (CreateJsConfigThatOverridesDefaultIncludeNullValuesSetting())
            {
                var expected = default(Instant);
                var dto = new TestDto<Instant?> { Value = default(Instant) };
                var serialized = dto.ToJson();
                var deserialized = serialized.FromJson<TestDto<Instant?>>();
                var actual = deserialized.Value;

                Assert.That(actual, Is.EqualTo(expected));
            }
        }

        private const string ExpectedIntervalFormatString = "{{\"Start\":{0},\"End\":{1}}}";

        [TestCaseSource(nameof(ExpectedNodaTimeInstantJson))]
        public void NodaTimeInterval_SerializesToExpectedText_WithVaryingStart(Instant start, string expectedStart)
        {
            const string expectedEnd = "\"MaxInstant\"";
            var expected = String.Format(ExpectedIntervalFormatString, expectedStart, expectedEnd);
            var input = new Interval(start, Instant.MaxValue);

            var actual = input.ToJson();

            Assert.That(actual, Is.EqualTo(expected));
        }

        [TestCaseSource(nameof(ExpectedNodaTimeInstantJson))]
        public void NodaTimeInterval_SerializesToExpectedText_WithVaryingEnd(Instant end, string expectedEnd)
        {
            const string expectedStart = "\"MinInstant\"";
            var expected = String.Format(ExpectedIntervalFormatString, expectedStart, expectedEnd);
            var input = new Interval(Instant.MinValue, end);

            var actual = input.ToJson();

            Assert.That(actual, Is.EqualTo(expected));
        }

        [TestCaseSource(nameof(ExpectedNodaTimeInstantJson))]
        public void NodaTimeInterval_RoundTrip_ReturnsSameValue_WithVaryingStart(Instant start, string ignore)
        {
            var input = new Interval(start, Instant.MaxValue);

            var json = input.ToJson();
            var actual = json.FromJson<Interval>();

            Assert.That(actual, Is.EqualTo(input));
        }

        [TestCaseSource(nameof(ExpectedNodaTimeInstantJson))]
        public void NodaTimeInterval_RoundTrip_ReturnsSameValue_WithVaryingEnd(Instant end, string ignore)
        {
            var input = new Interval(Instant.MinValue, end);

            var json = input.ToJson();
            var actual = json.FromJson<Interval>();

            Assert.That(actual, Is.EqualTo(input));
        }

        public readonly object[][] ExpectedJsonNodaTimeIntervals =
        {
            new object[] {"{\"Start\":\"MinInstant\",\"End\":\"MaxInstant\"}", Instant.MinValue, Instant.MaxValue},
            new object[] {"{\"stART\":\"minINSTAnt\",\"eND\":\"MAxinSTANT\"}", Instant.MinValue, Instant.MaxValue},
            new object[]
            {
                "{\"Start\":\"1901-02-03T04:05:06.789Z\",\"End\":\"MaxInstant\"}",
                Instant.FromDateTimeUtc(ArbitraryUtcDate),
                Instant.MaxValue
            },
            new object[]
            {
                "{\"Start\":\"MinInstant\",\"End\":\"1901-02-03T04:05:06.789Z\"}",
                Instant.MinValue,
                Instant.FromDateTimeUtc(ArbitraryUtcDate)
            }
        };

        [TestCaseSource(nameof(ExpectedJsonNodaTimeIntervals))]
        public void NodaTimeInterval_ParsesVariousValues(string json, Instant expectedStart, Instant expectedEnd)
        {
            var actual = json.FromJson<Interval>();

            Assert.That(actual, Is.EqualTo(new Interval(expectedStart, expectedEnd)));
        }

        [Test]
        public void NodaTimeInterval_UsingJsConfigThatOverridesDefaultIncludeNullValues_SerializesDefaultValue()
        {
            using (CreateJsConfigThatOverridesDefaultIncludeNullValuesSetting())
            {
                var defaultValue = default(Interval);
                var expected = GetJsonForDtoWithValue("{\"Start\":\"1970-01-01T00:00:00Z\",\"End\":\"1970-01-01T00:00:00Z\"}");

                var dto = new TestDto<Interval> { Value = defaultValue };
                var actual = dto.ToJson();

                Assert.That(actual, Is.EqualTo(expected));
            }
        }

        [Test]
        public void NodaTimeInterval_UsingJsConfigThatOverridesDefaultIncludeNullValues_RoundTripsDefaultValue()
        {
            using (CreateJsConfigThatOverridesDefaultIncludeNullValuesSetting())
            {
                var expected = default(Interval);
                var dto = new TestDto<Interval> { Value = new Interval() };
                var serialized = dto.ToJson();
                var deserialized = serialized.FromJson<TestDto<Interval>>();
                var actual = deserialized.Value;

                Assert.That(actual, Is.EqualTo(expected));
            }
        }

        private static readonly TimeSpan ArbitraryTimeSpan = new TimeSpan(1, 2, 3, 4, 567);

        public readonly object[][] ExpectedNodaTimeDurationJson =
        {
            new object[] {Duration.FromTimeSpan(ArbitraryTimeSpan), "\"P1DT2H3M4.567S\""},
            new object[] {Duration.FromTimeSpan(ArbitraryTimeSpan).Plus(Duration.FromTicks(1)), "\"P1DT2H3M4.5670001S\""},
            new object[] {Duration.FromTimeSpan(-ArbitraryTimeSpan), "\"-P1DT2H3M4.567S\""},
            new object[] {Duration.FromTimeSpan(-ArbitraryTimeSpan).Minus(Duration.FromTicks(1)), "\"-P1DT2H3M4.5670001S\""},
            new object[] {Duration.FromDays(1), "\"P1D\""},
            new object[] {Duration.FromMinutes(15), "\"PT15M\""},
            new object[] {Duration.FromMinutes(-15), "\"-PT15M\""},
            new object[] {Duration.Zero, "\"PT0S\""},
            new object[] {Duration.FromTicks(Int64.MaxValue), "\"MaxDuration\""},
            new object[] {DurationExtensions.MaxGapDuration, "\"MaxDuration\""},
            new object[] {Duration.FromTicks(Int64.MinValue), "\"MinDuration\""}
        };

        [TestCaseSource(nameof(ExpectedNodaTimeDurationJson))]
        public void NodaTimeDuration_SerializesToExpectedText(Duration input, string expected)
        {
            var actual = input.ToJson();

            Assert.That(actual, Is.EqualTo(expected));
        }

        public class NodaTimeDto
        {
            public Instant Instant { get; set; }
            public Interval Interval { get; set; }
            public Duration Duration { get; set; }
            public Offset Offset { get; set; }
        }

        [TestCaseSource(nameof(ExpectedNodaTimeDurationJson))]
        public void NodaTimeDuration_RoundTrip_ReturnsSameValue(Duration input, string ignore)
        {
            var json = input.ToJson();
            var actual = json.FromJson<Duration>();

            Assert.That(actual, Is.EqualTo(input));
        }

        public readonly IEnumerable<TestCaseData> ExpectedNodaTimeDto = new[]
        {
            new TestCaseData(new NodaTimeDto
            {
                Instant = Instant.FromDateTimeUtc(ArbitraryUtcDate),
                Interval = new Interval(Instant.FromDateTimeUtc(ArbitraryUtcDate), Instant.FromDateTimeUtc(ArbitraryUtcDate).Plus(Duration.FromDays(1))),
                Duration = Duration.FromTimeSpan(ArbitraryTimeSpan),
                Offset = ArbitraryOffset
            }),
        };

        [TestCaseSource(nameof(ExpectedNodaTimeDto))]
        public void NodaTimeDto_RoundTrip_ReturnsSameValue(NodaTimeDto input)
        {
            var json = input.ToJson();
            var actual = json.FromJson<NodaTimeDto>();

            actual.ShouldBeEquivalentTo(input, "Intermediate JSON={0}", json);
        }

        [Test]
        public void NodaTimeDuration_UsingJsConfigThatOverridesDefaultIncludeNullValues_SerializesDefaultValue()
        {
            using (CreateJsConfigThatOverridesDefaultIncludeNullValuesSetting())
            {
                var defaultValue = default(Duration);
                var expected = GetJsonForDtoWithValue("\"PT0S\"");

                var dto = new TestDto<Duration> { Value = defaultValue };
                var actual = dto.ToJson();

                Assert.That(actual, Is.EqualTo(expected));
            }
        }

        [Test]
        public void NodaTimeDuration_UsingJsConfigThatOverridesDefaultIncludeNullValues_RoundTripsDefaultValue()
        {
            using (CreateJsConfigThatOverridesDefaultIncludeNullValuesSetting())
            {
                var expected = default(Duration);
                var dto = new TestDto<Duration> { Value = default(Duration) };
                var serialized = dto.ToJson();
                var deserialized = serialized.FromJson<TestDto<Duration>>();
                var actual = deserialized.Value;

                Assert.That(actual, Is.EqualTo(expected));
            }
        }

        [Test]
        public void NodaTimeNullableDuration_UsingJsConfigThatOverridesDefaultIncludeNullValues_DoesNotSerializeDefaultValue()
        {
            using (CreateJsConfigThatOverridesDefaultIncludeNullValuesSetting())
            {
                const string expected = "{}";

                var dto = new TestDto<Duration?> { Value = default(Duration?) };
                var actual = dto.ToJson();

                Assert.That(actual, Is.EqualTo(expected));
            }
        }

        [Test]
        public void NodaTimeNullableDuration_UsingJsConfigThatOverridesDefaultIncludeNullValues_SerializesValueTypeDefaultValue()
        {
            using (CreateJsConfigThatOverridesDefaultIncludeNullValuesSetting())
            {
                var defaultValue = default(Duration);
                var expected = GetJsonForDtoWithValue("\"PT0S\"");

                var dto = new TestDto<Duration?> { Value = defaultValue };
                var actual = dto.ToJson();

                Assert.That(actual, Is.EqualTo(expected));
            }
        }

        [Test]
        public void NodaTimeNullableDuration_UsingJsConfigThatOverridesDefaultIncludeNullValues_RoundTripsDefaultValue()
        {
            using (CreateJsConfigThatOverridesDefaultIncludeNullValuesSetting())
            {
                var dto = new TestDto<Duration?> { Value = default(Duration?) };
                var serialized = dto.ToJson();
                var deserialized = serialized.FromJson<TestDto<Duration?>>();
                var actual = deserialized.Value;

                Assert.That(actual, Is.Null);
            }
        }

        [Test]
        public void NodaTimeNullableDuration_UsingJsConfigThatOverridesDefaultIncludeNullValues_RoundTripsValueTypeDefaultValue()
        {
            using (CreateJsConfigThatOverridesDefaultIncludeNullValuesSetting())
            {
                var expected = default(Duration);
                var dto = new TestDto<Duration?> { Value = default(Duration) };
                var serialized = dto.ToJson();
                var deserialized = serialized.FromJson<TestDto<Duration?>>();
                var actual = deserialized.Value;

                Assert.That(actual, Is.EqualTo(expected));
            }
        }

        public static readonly Offset ArbitraryOffset = Offset.FromHoursAndMinutes(8, 30);

        public readonly object[][] ExpectedNodaTimeOffsetJson =
        {
            new object[] {ArbitraryOffset, "\"PT8H30M\""},
            new object[] {-ArbitraryOffset, "\"-PT8H30M\""},
            new object[] {Offset.FromMilliseconds(1), "\"PT0.001S\""},
            new object[] {Offset.FromMilliseconds(-1), "\"-PT0.001S\""},
            new object[] {Offset.Zero, "\"PT0S\""}
        };

        [TestCaseSource(nameof(ExpectedNodaTimeOffsetJson))]
        public void NodaTimeOffset_SerializesToExpectedText(Offset input, string expected)
        {
            var actual = input.ToJson();

            Assert.That(actual, Is.EqualTo(expected));
        }

        [TestCaseSource(nameof(ExpectedNodaTimeOffsetJson))]
        public void NodaTimeOffset_RoundTrip_ReturnsSameValue(Offset input, string ignore)
        {
            var json = input.ToJson();
            var actual = json.FromJson<Offset>();

            Assert.That(actual, Is.EqualTo(input));
        }

        [Test]
        public void NodaTimeOffset_UsingJsConfigThatOverridesDefaultIncludeNullValues_SerializesDefaultValue()
        {
            using (CreateJsConfigThatOverridesDefaultIncludeNullValuesSetting())
            {
                var defaultValue = default(Offset);
                var expected = GetJsonForDtoWithValue("\"PT0S\"");

                var dto = new TestDto<Offset> { Value = defaultValue };
                var actual = dto.ToJson();

                Assert.That(actual, Is.EqualTo(expected));
            }
        }

        [Test]
        public void NodaTimeOffset_UsingJsConfigThatOverridesDefaultIncludeNullValues_RoundTripsDefaultValue()
        {
            using (CreateJsConfigThatOverridesDefaultIncludeNullValuesSetting())
            {
                var expected = default(Offset);
                var dto = new TestDto<Offset> { Value = default(Offset) };
                var serialized = dto.ToJson();
                var deserialized = serialized.FromJson<TestDto<Offset>>();
                var actual = deserialized.Value;

                Assert.That(actual, Is.EqualTo(expected));
            }
        }

        private class TestDto<T>
        {
            public T Value { get; set; }
        }

        private static string GetJsonForDtoWithValue(string value)
        {
            return Invariant($"{{\"Value\":{value}}}");
        }

        private static readonly List<TestCaseData> DoubleValues = new List<TestCaseData>
        {
            new TestCaseData(1234.0123456789012, "1234.0123456789013"),
            new TestCaseData(6.0221415E23, "6.0221415E+23"),
            new TestCaseData(1.0 / 3.0, "0.33333333333333331"),
            new TestCaseData(Math.PI, "3.1415926535897931"),
            new TestCaseData(Math.E, "2.7182818284590451"),
            new TestCaseData(double.MaxValue, "1.7976931348623157E+308"),
            new TestCaseData(double.MinValue, "-1.7976931348623157E+308"),
            new TestCaseData(double.Epsilon, "4.94065645841247E-324"),
        };

        private static readonly List<TestCaseData> DoubleSpecificValues = new List<TestCaseData>
        {
            new TestCaseData(double.NaN, "null"),
        };

        private static readonly List<TestCaseData> NullableDoubleSpecificValues = new List<TestCaseData>
        {
            new TestCaseData(null, "null"),
        };

        private static readonly List<TestCaseData> NullableDoubleAsymmetricValues = new List<TestCaseData>
        {
            new TestCaseData(double.NaN, "null", null),
        };

        private static readonly List<TestCaseData> DoubleValuesNotSupportedByJson = new List<TestCaseData>
        {
            new TestCaseData(double.PositiveInfinity),
            new TestCaseData(double.NegativeInfinity),
        };

        [TestCaseSource(nameof(DoubleValues))]
        public void Double_SerializesToExpectedText(double input, string valueString)
        {
            var dto = new TestDto<double> { Value = input };
            var actual = dto.ToJson();

            var expected = GetJsonForDtoWithValue(valueString);

            Assert.That(actual, Is.EqualTo(expected));
        }

        [TestCaseSource(nameof(DoubleSpecificValues))]
        [TestCaseSource(nameof(DoubleValues))]
        public void Double_ParsesToExpectedValue(double expected, string input)
        {
            var serialized = GetJsonForDtoWithValue(input);
            var deserialized = serialized.FromJson<TestDto<double>>();
            var actual = deserialized.Value;

            Assert.That(actual, Is.EqualTo(expected));
        }

        [TestCaseSource(nameof(DoubleSpecificValues))]
        [TestCaseSource(nameof(DoubleValues))]
        public void Double_RoundTrip_ReturnsSameValue(double input, string ignore)
        {
            var dto = new TestDto<double> { Value = input };
            var serialized = dto.ToJson();
            var deserialized = serialized.FromJson<TestDto<double>>();
            var actual = deserialized.Value;

            Assert.That(actual, Is.EqualTo(input));
        }

        [TestCaseSource(nameof(DoubleValuesNotSupportedByJson))]
        public void Double_InvalidJsonValue_Throws(double input)
        {
            var dto = new TestDto<double> { Value = input };

            Assert.That(() => dto.ToJson(), Throws.InstanceOf<ArgumentException>()
                .With.Property("ParamName").StringContaining("value"));
        }

        [Test]
        public void Double_UsingJsConfigThatOverridesDefaultIncludeNullValues_SerializesDefaultValue()
        {
            using (CreateJsConfigThatOverridesDefaultIncludeNullValuesSetting())
            {
                const double defaultValue = default(double);
                var expected = GetJsonForDtoWithValue(defaultValue.ToString(CultureInfo.InvariantCulture));

                var dto = new TestDto<double> { Value = defaultValue };
                var actual = dto.ToJson();

                Assert.That(actual, Is.EqualTo(expected));
            }
        }

        [Test]
        public void Double_UsingJsConfigThatOverridesDefaultIncludeNullValues_RoundTripsDefaultValue()
        {
            using (CreateJsConfigThatOverridesDefaultIncludeNullValuesSetting())
            {
                const double expected = default(double);
                var dto = new TestDto<double> { Value = default(double) };
                var serialized = dto.ToJson();
                var deserialized = serialized.FromJson<TestDto<double>>();
                var actual = deserialized.Value;

                Assert.That(actual, Is.EqualTo(expected));
            }
        }

        [TestCaseSource(nameof(NullableDoubleSpecificValues))]
        [TestCaseSource(nameof(DoubleValues))]
        public void NullableDouble_SerializesToExpectedText(double? input, string valueString)
        {
            var dto = new TestDto<double?> { Value = input };
            var actual = dto.ToJson();

            var expected = GetJsonForDtoWithValue(valueString);

            Assert.That(actual, Is.EqualTo(expected));
        }

        [TestCaseSource(nameof(NullableDoubleSpecificValues))]
        [TestCaseSource(nameof(DoubleValues))]
        public void NullableDouble_ParsesToExpectedValue(double? expected, string input)
        {
            var serialized = GetJsonForDtoWithValue(input);
            var deserialized = serialized.FromJson<TestDto<double?>>();
            var actual = deserialized.Value;

            Assert.That(actual, Is.EqualTo(expected));
        }

        [TestCaseSource(nameof(NullableDoubleSpecificValues))]
        [TestCaseSource(nameof(DoubleValues))]
        public void NullableDouble_RoundTrip_ReturnsSameValue(double? input, string ignore)
        {
            var dto = new TestDto<double?> { Value = input };
            var serialized = dto.ToJson();
            var deserialized = serialized.FromJson<TestDto<double?>>();
            var actual = deserialized.Value;

            Assert.That(actual, Is.EqualTo(input));
        }

        [TestCaseSource(nameof(NullableDoubleAsymmetricValues))]
        public void NullableDouble_RoundTrip_ReturnsExpectedValue(double? input, string ignore, double? expected)
        {
            var dto = new TestDto<double?> { Value = input };
            var serialized = dto.ToJson();
            var deserialized = serialized.FromJson<TestDto<double?>>();
            var actual = deserialized.Value;

            Assert.That(actual, Is.EqualTo(expected));
        }

        [TestCaseSource(nameof(DoubleValuesNotSupportedByJson))]
        public void NullableDouble_InvalidJsonValue_Throws(double? input)
        {
            var dto = new TestDto<double?> { Value = input };

            Assert.That(() => dto.ToJson(), Throws.InstanceOf<ArgumentException>()
                .With.Property("ParamName").StringContaining("value"));
        }

        [Test]
        public void NullableDouble_UsingJsConfigThatOverridesDefaultIncludeNullValues_DoesNotSerializeDefaultValue()
        {
            using (CreateJsConfigThatOverridesDefaultIncludeNullValuesSetting())
            {
                const string expected = "{}";

                var dto = new TestDto<double?> { Value = default(double?) };
                var actual = dto.ToJson();

                Assert.That(actual, Is.EqualTo(expected));
            }
        }

        [Test]
        public void NullableDouble_UsingJsConfigThatOverridesDefaultIncludeNullValues_SerializesValueTypeDefaultValue()
        {
            using (CreateJsConfigThatOverridesDefaultIncludeNullValuesSetting())
            {
                const double defaultValue = default(double);
                var expected = GetJsonForDtoWithValue(defaultValue.ToString(CultureInfo.InvariantCulture));

                var dto = new TestDto<double?> { Value = defaultValue };
                var actual = dto.ToJson();

                Assert.That(actual, Is.EqualTo(expected));
            }
        }

        [Test]
        public void NullableDouble_UsingJsConfigThatOverridesDefaultIncludeNullValues_RoundTripsDefaultValue()
        {
            using (CreateJsConfigThatOverridesDefaultIncludeNullValuesSetting())
            {
                var dto = new TestDto<double?> { Value = default(double?) };
                var serialized = dto.ToJson();
                var deserialized = serialized.FromJson<TestDto<double?>>();
                var actual = deserialized.Value;

                Assert.That(actual, Is.Null);
            }
        }

        [Test]
        public void NullableDouble_UsingJsConfigThatOverridesDefaultIncludeNullValues_RoundTripsValueTypeDefaultValue()
        {
            using (CreateJsConfigThatOverridesDefaultIncludeNullValuesSetting())
            {
                const double expected = default(double);
                var dto = new TestDto<double?> { Value = default(double) };
                var serialized = dto.ToJson();
                var deserialized = serialized.FromJson<TestDto<double?>>();
                var actual = deserialized.Value;

                Assert.That(actual, Is.EqualTo(expected));
            }
        }

        [Test]
        public void EnumWithoutUnknownDefault_WithUnexpectedValue_Throws()
        {
            AssertEnumDoesNotHaveUnknownDefault<CorrectionProcessingOrder>();

            var jsonText = $"\"{GetDefaultEnumValue<CorrectionProcessingOrder>()}_SomeValueThatWontBeExpected\"";

            Action action = () => jsonText.FromJson<CorrectionProcessingOrder>();

            action.ShouldThrow<ArgumentException>();
        }


        [Test]
        public void EnumWithUnknownDefault_WithUnexpectedValue_DeserializesToUnknown()
        {
            AssertEnumHasUnknownDefault<FlowDirectionType>();

            var defaultValue = GetDefaultEnumValue<FlowDirectionType>();

            var jsonText = $"\"{defaultValue}_SomeValueThatWontBeExpected\"";

            var actual = jsonText.FromJson<FlowDirectionType>();

            actual.ShouldBeEquivalentTo(defaultValue);
        }

        private void AssertEnumHasUnknownDefault<TEnum>() where TEnum : struct
        {
            var defaultValue = GetDefaultEnumValue<TEnum>();

            defaultValue.ToString().ToLowerInvariant().ShouldBeEquivalentTo("unknown", $"{typeof(TEnum).FullName} should have a default value of 'Unknown'");
        }

        private void AssertEnumDoesNotHaveUnknownDefault<TEnum>() where TEnum : struct
        {
            var defaultValue = GetDefaultEnumValue<TEnum>();

            defaultValue.ToString().ToLowerInvariant().Should().NotBe("unknown", $"{typeof(TEnum).FullName} should NOT have a default value of 'Unknown'");
        }

        private TEnum GetDefaultEnumValue<TEnum>() where TEnum : struct
        {
            return default(TEnum);
        }
    }
}
