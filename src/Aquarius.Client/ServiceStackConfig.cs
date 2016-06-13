using System;
using System.Globalization;
using System.Text.RegularExpressions;
using Aquarius.Client.Helpers;
using Aquarius.Client.ServiceModels.Publish;
using NodaTime;
using ServiceStack;
using ServiceStack.Text;
using ServiceStack.Text.Common;

namespace Aquarius.Client
{
    // Munged together from Server.Services.ServiceStack, but stripped of MsgPack references for easier deployment
    public class ServiceStackConfig
    {
        private static bool _configured;
        private static readonly object SyncLock = new object();

        public static void ConfigureServiceStack()
        {
            lock (SyncLock)
            {
                if (_configured)
                    return;

                JsonConfig.ConfigureJson();
                ConfigurePublishApiJson();

                _configured = true;
            }
        }

        private static void ConfigurePublishApiJson()
        {
            JsConfig<StatisticalDateTimeOffset>.SerializeFn = DateTimeOffsetSerializer.SerializeToJsonLikeFormat;
            JsConfig<StatisticalDateTimeOffset>.DeSerializeFn = DateTimeOffsetSerializer.DeserializeFromJsonLikeFormat;
        }
    }

    // Also lifted from Server.Services.ServiceStack
    public class JsonConfig
    {
        private static readonly Regex XsdDateTimeStringRegex = new Regex(@"\.[0-9]{2}Z", RegexOptions.Compiled);

        internal class IntervalDto
        {
            public Instant Start { get; set; }
            public Instant End { get; set; }
        }

        internal static void ConfigureJson()
        {
            JsConfig.DateHandler = DateHandler.ISO8601;
            JsConfig.AlwaysUseUtc = true;
            JsConfig.AssumeUtc = true;
            JsConfig.IncludeNullValues = true;
            JsConfig.IncludeNullValuesInDictionaries = true;

            JsConfig<DateTime>.SerializeFn = AlwaysSerializeDateTimeAsUtc;
            JsConfig<DateTime>.DeSerializeFn = AlwaysDeserializeDateTimeAsUtc;

            JsConfig<Instant>.SerializeFn = SerializeInstant;
            JsConfig<Instant>.DeSerializeFn = DeserializeInstant;

            JsConfig<Interval>.RawSerializeFn = SerializeInterval;
            JsConfig<Interval>.RawDeserializeFn = DeserializeInterval;

            JsConfig<Duration>.RawSerializeFn = SerializeDuration;
            JsConfig<Duration>.DeSerializeFn = DeserializeDuration;

            JsConfig<Offset>.RawSerializeFn = SerializeOffset;
            JsConfig<Offset>.DeSerializeFn = DeserializeOffset;
        }

        private static string AlwaysSerializeDateTimeAsUtc(DateTime dateTime)
        {
            dateTime = ForceKindToUtc(dateTime);

            var dateTimeString = DateTimeSerializer.ToXsdDateTimeString(dateTime);
            return GetStableXsdDateTimeString(dateTimeString);
        }

        // AQ-17088 : Remove this hack when ServiceStack is upgraded to 4.0.43+
        private static string GetStableXsdDateTimeString(string dateTimeString)
        {
            if (!XsdDateTimeStringRegex.IsMatch(dateTimeString))
                return dateTimeString;

            var dateTimeStringWithoutUtcSuffix = dateTimeString.Substring(0, dateTimeString.Length - 1);
            return dateTimeStringWithoutUtcSuffix + "0Z";
        }

        private static DateTime AlwaysDeserializeDateTimeAsUtc(string s)
        {
            var dateTime = DateTimeSerializer.ParseShortestXsdDateTime(s);

            dateTime = ForceKindToUtc(dateTime);

            return dateTime;
        }

        private static DateTime ForceKindToUtc(DateTime dateTime)
        {
            if (dateTime.Kind == DateTimeKind.Utc) return dateTime;

            var utcDateTime = new DateTime(dateTime.Ticks, DateTimeKind.Utc);

            return utcDateTime;
        }

        private static string SerializeInstant(Instant value)
        {
            if (value == Instant.MinValue)
                return "MinInstant";
            if (value == Instant.MaxValue)
                return "MaxInstant";
            return DateTimeSerializer.ToXsdDateTimeString(value.ToDateTimeUtc());
        }

        private static Instant DeserializeInstant(string text)
        {
            switch (text.ToLowerInvariant())
            {
                case "mininstant":
                    return Instant.MinValue;
                case "maxinstant":
                    return Instant.MaxValue;
                default:
                    var dateTimeOffset = DateTimeSerializer.ParseDateTimeOffset(text);
                    return Instant.FromDateTimeOffset(dateTimeOffset);
            }
        }

        private static string SerializeInterval(Interval value)
        {
            var dto = new IntervalDto
            {
                Start = value.Start,
                End = value.End
            };
            return dto.ToJson();
        }

        private static Interval DeserializeInterval(string json)
        {
            var dto = json.FromJson<IntervalDto>();
            return new Interval(dto.Start, dto.End);
        }

        private static string SerializeDuration(Duration value)
        {
            return value.SerializeToQuotedString();
        }

        private static Duration DeserializeDuration(string text)
        {
            return text.ParseDuration();
        }

        private static string SerializeOffset(Offset value)
        {
            return TextExtensions.SerializeToString(value.ToTimeSpan());
        }

        private static Offset DeserializeOffset(string text)
        {
            return Offset.FromTicks(text.FromJson<TimeSpan>().Ticks);
        }
    }

    // Lifted from Server.Services.PublishService.ServiceInterface, and modified to inclde a deserializer
    public static class DateTimeOffsetSerializer
    {
        private const string EndOfDayMidnightLiteral = "T24:00:00.0000000";
        private const string EndOfDayMidnightRoundtripFormat = "yyyy'-'MM'-'dd'" + EndOfDayMidnightLiteral + "'zzz";

        public static string SerializeToJsonLikeFormat(StatisticalDateTimeOffset statisticalDateTimeOffset)
        {
            if (statisticalDateTimeOffset.RepresentsEndOfTimePeriod && IsMidnight(statisticalDateTimeOffset.DateTimeOffset))
            {
                return SerializeEndOfDayMidnight(statisticalDateTimeOffset.DateTimeOffset);
            }
            return SerializeToNormalRoundtripFormat(statisticalDateTimeOffset.DateTimeOffset);
        }

        private static bool IsMidnight(DateTimeOffset dateTimeOffset)
        {
            return dateTimeOffset.TimeOfDay == TimeSpan.Zero;
        }

        private static string SerializeEndOfDayMidnight(DateTimeOffset dateTimeOffset)
        {
            var previousDayJustBeforeMidnight = dateTimeOffset.AddSeconds(-1);
            return previousDayJustBeforeMidnight.ToString(EndOfDayMidnightRoundtripFormat, CultureInfo.InvariantCulture);
        }

        private static string SerializeToNormalRoundtripFormat(DateTimeOffset dateTimeOffset)
        {
            return dateTimeOffset.ToString("o", CultureInfo.InvariantCulture);
        }

        private static readonly string[] ExactFormats = {"o", EndOfDayMidnightRoundtripFormat};
        private static readonly TimeSpan Midnight = TimeSpan.Zero;

        public static StatisticalDateTimeOffset DeserializeFromJsonLikeFormat(string s)
        {
            var dateTimeOffset = DateTimeOffset.ParseExact(s, ExactFormats, CultureInfo.InvariantCulture, DateTimeStyles.None);

            if (dateTimeOffset.TimeOfDay == Midnight && s.Contains(EndOfDayMidnightLiteral))
            {
                return new StatisticalDateTimeOffset
                {
                    RepresentsEndOfTimePeriod = true,
                    DateTimeOffset = dateTimeOffset + TimeSpan.FromDays(1)
                };
            }

            return new StatisticalDateTimeOffset
            {
                RepresentsEndOfTimePeriod = false,
                DateTimeOffset = dateTimeOffset
            };
        }
    }
}
