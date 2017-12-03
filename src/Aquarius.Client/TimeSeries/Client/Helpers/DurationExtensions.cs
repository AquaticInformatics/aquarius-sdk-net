using System;
using System.Xml;
using NodaTime;

namespace Aquarius.TimeSeries.Client.Helpers
{
    public static class DurationExtensions
    {
        private static string MaxDurationString = "MaxDuration";
        private static string MinDurationString = "MinDuration";

        private static readonly Duration DurationMaxValue = Duration.FromTicks(Int64.MaxValue);
        private static readonly Duration DurationMinValue = Duration.FromTicks(Int64.MinValue);

        public static readonly Duration MaxGapDuration = DurationMaxValue;

        private static readonly StringComparer DurationComparer = StringComparer.InvariantCultureIgnoreCase;

        public static Duration ParseDuration(this string s)
        {
            if (DurationComparer.Equals(s, MaxDurationString))
                return DurationMaxValue;
            if (DurationComparer.Equals(s, MinDurationString))
                return DurationMinValue;

            var parsedTimeSpan = XmlConvert.ToTimeSpan(s);
            return Duration.FromTimeSpan(parsedTimeSpan);
        }

        public static string SerializeToQuotedString(this Duration value)
        {
            var durationAsString = value.SerializeToString();

            const string durationStringFormat = "\"{0}\"";
            return string.Format(durationStringFormat, durationAsString);
        }

        public static string SerializeToString(this Duration value)
        {
            if (value == DurationMaxValue)
                return MaxDurationString;

            if (value == DurationMinValue)
                return MinDurationString;

            var valueAsTimeSpan = value.ToTimeSpan();
            return XmlConvert.ToString(valueAsTimeSpan);
        }
    }
}
