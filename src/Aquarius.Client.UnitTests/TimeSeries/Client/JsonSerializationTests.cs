using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Aquarius.Client.UnitTests.TestHelpers;
using Aquarius.TimeSeries.Client;
using Aquarius.TimeSeries.Client.Helpers;
using Aquarius.TimeSeries.Client.ServiceModels.Publish;
using FluentAssertions;
using NodaTime;
using NUnit.Framework;
using ServiceStack;
using ServiceStack.Logging;
using ServiceStack.Text;

namespace Aquarius.UnitTests.TimeSeries.Client
{
    public class JsonSerializationTests
    {
        private static readonly DateTime ArbitraryUtcDate = new DateTime(1901, 02, 03, 04, 05, 06, DateTimeKind.Utc).AddMilliseconds(789);

        [OneTimeSetUp]
        public void BeforeAnyTests()
        {
            SetupLogging();

            ServiceStackConfig.ConfigureServiceStack();
        }

        private class MyLogger : ILog
        {
            private void Write(string prefix, object message)
            {
                Console.WriteLine($"{prefix}: {message}");
            }

            private void Write(string prefix, string format, params object[] args)
            {
                Console.WriteLine($"{prefix}: {string.Format(format, args)}");
            }

            private void Write(string prefix, object message, Exception exception)
            {
                Console.WriteLine($"{prefix}: {message}: {exception.Message}\n{exception.StackTrace}");
            }

            public void Debug(object message)
            {
                Write("DEBUG", message);
            }

            public void Debug(object message, Exception exception)
            {
                Write("DEBUG", message, exception);
            }

            public void DebugFormat(string format, params object[] args)
            {
                Write("DEBUG", format, args);
            }

            public void Error(object message)
            {
                Write("ERROR", message);
            }

            public void Error(object message, Exception exception)
            {
                Write("ERROR", message, exception);
            }

            public void ErrorFormat(string format, params object[] args)
            {
                Write("ERROR", format, args);
            }

            public void Fatal(object message)
            {
                Write("FATAL", message);
            }

            public void Fatal(object message, Exception exception)
            {
                Write("FATAL", message, exception);
            }

            public void FatalFormat(string format, params object[] args)
            {
                Write("FATAL", format, args);
            }

            public void Info(object message)
            {
                Write("INFO", message);
            }

            public void Info(object message, Exception exception)
            {
                Write("INFO", message, exception);
            }

            public void InfoFormat(string format, params object[] args)
            {
                Write("INFO", format, args);
            }

            public void Warn(object message)
            {
                Write("WARN", message);
            }

            public void Warn(object message, Exception exception)
            {
                Write("WARN", message, exception);
            }

            public void WarnFormat(string format, params object[] args)
            {
                Write("WARN", format, args);
            }

            public bool IsDebugEnabled { get; } = true;
        }

        private class MyLoggerFactory : ILogFactory
        {
            private static readonly ILog Logger = new MyLogger();
            public ILog GetLogger(Type type)
            {
                return Logger;
            }

            public ILog GetLogger(string typeName)
            {
                return Logger;
            }
        }

        private void SetupLogging()
        {
            LogManager.LogFactory = new MyLoggerFactory();

        }


        private static readonly IEnumerable<TestCaseData> FractionalSecondsTestCases = new[]
        {
            new TestCaseData(ArbitraryUtcDate.Subtract(TimeSpan.FromMilliseconds(ArbitraryUtcDate.Millisecond)), "\"1901-02-03T04:05:06Z\"", "No fractional seconds"),
            new TestCaseData(ArbitraryUtcDate, "\"1901-02-03T04:05:06.789Z\"", "3-fractional second precision"),
            new TestCaseData(ArbitraryUtcDate.AddTicks(1234), "\"1901-02-03T04:05:06.7891234Z\"", "7-fractional second precision"),
        };

        [TestCaseSource(nameof(FractionalSecondsTestCases))]
        public void DateTime_SerializesToExpectedText(DateTime dateTime, string expected, string reason)
        {
            var actual = dateTime.ToJson();

            actual.ShouldBeEquivalentTo(expected, reason);
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

        private static readonly object[][] ExpectedNodaTimeInstantJson =
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

        private static readonly object[][] ExpectedJsonNodaTimeInstants =
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
        public void NodaTimeInstant_ParsesSamplesTimestampWithTimeCode()
        {
            NodaTimeInstant_ParsesVariousValues(
                "\"1901-02-03T08:05:06.789+04:00[GST]\"", // Gulf Standard Time
                Instant.FromDateTimeUtc(ArbitraryUtcDate));

            // AQS-760 workaround for goofy timestamps without a time component
            NodaTimeInstant_ParsesVariousValues(
                "\"2020-12-01T-08:00\"", // This occurred in on a production system
                Instant.FromUtc(2020, 12, 01, 0, 0).Minus(Duration.FromHours(-8)));

            NodaTimeInstant_ParsesVariousValues(
                "\"2020-12-01T+10:00\"", // What if the timezone was in Australia?
                Instant.FromUtc(2020, 12, 01, 0, 0).Minus(Duration.FromHours(10)));
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

        private static readonly object[][] ExpectedJsonNodaTimeIntervals =
        {
            new object[] {"{\"Start\":\"MinInstant\",\"End\":\"MaxInstant\"}", new Interval(Instant.MinValue, Instant.MaxValue)},
            new object[] {"{\"stART\":\"minINSTAnt\",\"eND\":\"MAxinSTANT\"}", new Interval(Instant.MinValue, Instant.MaxValue)},
            new object[] {"{\"Start\":\"1901-02-03T04:05:06.789Z\",\"End\":\"MaxInstant\"}", new Interval(Instant.FromDateTimeUtc(ArbitraryUtcDate), Instant.MaxValue)},
            new object[] {"{\"Start\":\"MinInstant\",\"End\":\"1901-02-03T04:05:06.789Z\"}", new Interval(Instant.MinValue, Instant.FromDateTimeUtc(ArbitraryUtcDate))},
        };

        private static readonly object[][] ExpectedJsonNodaTimeNullableIntervals =
            ExpectedJsonNodaTimeIntervals
                .Select(o => new object[] {o[0], o[1]})
                .Concat(new []
                {
                    new object[] {(string)null, (Interval?)null}
                })
                .ToArray();


        [TestCaseSource(nameof(ExpectedJsonNodaTimeNullableIntervals))]
        public void NodaTimeNullableInterval_DeserializesFromJson(string json, Interval? expected)
        {
            var actual = json.FromJson<Interval?>();

            Assert.That(actual, Is.EqualTo(expected));
        }

        [TestCaseSource(nameof(ExpectedJsonNodaTimeIntervals))]
        public void NodaTimeNullableInterval_SerializesToJson(string expectedJson, Interval? interval)
        {
            var actual = interval.ToJson();

            Assert.That(actual, Is.EqualTo(expectedJson).IgnoreCase);
        }

        [TestCaseSource(nameof(ExpectedJsonNodaTimeIntervals))]
        public void NodaTimeInterval_DeserializesFromJson(string json, Interval expected)
        {
            var actual = json.FromJson<Interval>();

            Assert.That(actual, Is.EqualTo(expected));
        }

        [TestCaseSource(nameof(ExpectedJsonNodaTimeIntervals))]
        public void NodaTimeInterval_SerializesToJson(string expectedJson, Interval interval)
        {
            var actual = interval.ToJson();

            Assert.That(actual, Is.EqualTo(expectedJson).IgnoreCase);
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

        private static readonly object[][] ExpectedNodaTimeDurationJson =
        {
            new object[] {Duration.FromTimeSpan(ArbitraryTimeSpan), "\"P1DT2H3M4.567S\""},
            new object[] {Duration.FromTimeSpan(ArbitraryTimeSpan).Plus(Duration.FromTicks(1)), "\"P1DT2H3M4.5670001S\""},
            new object[] {Duration.FromTimeSpan(-ArbitraryTimeSpan), "\"-P1DT2H3M4.567S\""},
            new object[] {Duration.FromTimeSpan(-ArbitraryTimeSpan).Minus(Duration.FromTicks(1)), "\"-P1DT2H3M4.5670001S\""},
            new object[] {NodaTimeHelpers.DurationFromDays(1), "\"P1D\""},
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

        private static readonly IEnumerable<TestCaseData> ExpectedNodaTimeDto = new[]
        {
            new TestCaseData(new NodaTimeDto
            {
                Instant = Instant.FromDateTimeUtc(ArbitraryUtcDate),
                Interval = new Interval(Instant.FromDateTimeUtc(ArbitraryUtcDate), Instant.FromDateTimeUtc(ArbitraryUtcDate).Plus(NodaTimeHelpers.DurationFromDays(1))),
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

        private static readonly Offset ArbitraryOffset = Offset.FromHoursAndMinutes(8, 30);

        private static readonly object[][] ExpectedNodaTimeOffsetJson =
        {
            new object[] {ArbitraryOffset, "\"PT8H30M\""},
            new object[] {-ArbitraryOffset, "\"-PT8H30M\""},
#if NODATIME1
            // NodaTime 2.x has dropped support for subsecond precision
            new object[] {Offset.FromMilliseconds(1), "\"PT0.001S\""},
            new object[] {Offset.FromMilliseconds(-1), "\"-PT0.001S\""},
#endif
            new object[] {Offset.FromMilliseconds(1000), "\"PT1S\""},
            new object[] {Offset.FromMilliseconds(-1000), "\"-PT1S\""},
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
            return $"{{\"Value\":{value}}}";
        }

        private static readonly List<TestCaseData> DoubleValues = new List<TestCaseData>
        {
            new TestCaseData(1234.0123456789012, "1234.0123456789013"),
            new TestCaseData(6.0221415E23, "6.0221415E+23"),
            new TestCaseData(1.0 / 3.0,
#if NETFRAMEWORK
                "0.33333333333333331"
#else
                "0.3333333333333333"
#endif
                ),
            new TestCaseData(Math.PI,
#if NETFRAMEWORK
                "3.1415926535897931"
#else
                "3.141592653589793"
#endif
                ),
            new TestCaseData(Math.E,
#if NETFRAMEWORK
                "2.7182818284590451"
#else
                "2.718281828459045"
#endif
                ),
            new TestCaseData(double.MaxValue, "1.7976931348623157E+308"),
            new TestCaseData(double.MinValue, "-1.7976931348623157E+308"),
            new TestCaseData(double.Epsilon,
#if NETFRAMEWORK
                "4.94065645841247E-324"
#else
                "5E-324"
#endif
                ),
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
                .With.Property("ParamName").Contains("value"));
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
                .With.Property("ParamName").Contains("value"));
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

            var log = LogManager.GetLogger("thing");

            log.Info($"jsonText={jsonText}");
            Action action = () => jsonText.FromJson<CorrectionProcessingOrder>();

            action.ShouldThrow<ArgumentException>();

            log.Info("Test completed");
        }


        [Test]
        public void EnumWithUnknownDefault_WithUnexpectedValue_DeserializesToUnknown()
        {
            AssertEnumHasUnknownDefault<FlowDirectionType>();

            var defaultValue = GetDefaultEnumValue<FlowDirectionType>();

            var jsonText = $"\"{defaultValue}_SomeValueThatWontBeExpected\"";

            var log = LogManager.GetLogger("thing");

            log.Info($"jsonText={jsonText}");

            var actual = jsonText.FromJson<FlowDirectionType>();

            actual.ShouldBeEquivalentTo(defaultValue);

            log.Info("Test completed");
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
