using System;
using NodaTime;
using NodaTime.Text;

namespace Aquarius.Client.Helpers
{
    public static class NodaTimeConverter
    {
        public static readonly DateTime MinDateTimeUtc = DateTime.SpecifyKind(DateTime.MinValue, DateTimeKind.Utc);
        public static readonly DateTime MaxDateTimeUtc = DateTime.SpecifyKind(DateTime.MaxValue, DateTimeKind.Utc);

        public static readonly Instant MinDateTimeInstant = Instant.FromDateTimeUtc(MinDateTimeUtc);
        public static readonly Instant MaxDateTimeInstant = Instant.FromDateTimeUtc(MaxDateTimeUtc);

        public static readonly OffsetDateTime MinOffsetDateTime = Instant.MinValue.WithOffset(Offset.Zero);
        public static readonly OffsetDateTime MaxOffsetDateTime = Instant.MaxValue.WithOffset(Offset.Zero);

        public static readonly LocalDateTime MinDateTimeLocalDateTime = LocalDateTime.FromDateTime(DateTime.MinValue);
        public static readonly LocalDateTime MaxDateTimeLocalDateTime = LocalDateTime.FromDateTime(DateTime.MaxValue);

        public static DateTime ToDateTimeUtc(Instant instant)
        {
            if (instant == Instant.MinValue)
                return MinDateTimeUtc;
            if (instant == Instant.MaxValue)
                return MaxDateTimeUtc;

            if ((instant <= MinDateTimeInstant) || (instant >= MaxDateTimeInstant))
                throw new ArgumentOutOfRangeException("instant", "Time not within allowable range, MinValue, or MaxValue");

            return instant.ToDateTimeUtc();
        }

        public static DateTimeOffset InstantToDateTimeOffsetUtc(Instant instant)
        {
            return new DateTimeOffset(ToDateTimeUtc(instant));
        }

        public static DateTime? ToNullableDateTimeUtc(Instant? instant)
        {
            return instant.HasValue ? ToNullableDateTimeUtc(instant.Value) : null;
        }

        private static DateTime? ToNullableDateTimeUtc(Instant instant)
        {
            return (instant == Instant.MinValue || instant == Instant.MaxValue)
                ? (DateTime?)null
                : ToDateTimeUtc(instant);
        }

        public static DateTimeOffset? InstantToNullableDateTimeOffsetUtc(Instant instant)
        {
            return ToNullableDateTimeUtc(instant);
        }

        public static DateTimeOffset? NullableInstantToNullableDateTimeOffsetUtc(Instant? instant)
        {
            return ToNullableDateTimeUtc(instant);
        }

        public static Instant UtcDateTimeToInstant(DateTime utcDateTime)
        {
            if (utcDateTime == MinDateTimeUtc)
                return Instant.MinValue;
            if (utcDateTime == MaxDateTimeUtc)
                return Instant.MaxValue;

            return Instant.FromDateTimeUtc(utcDateTime);
        }

        public static Instant UtcDateTimeAllowingUnspecifiedKindToInstant(DateTime utcDateTime)
        {
            if (utcDateTime.Kind == DateTimeKind.Local)
                throw new ArgumentException();

            return UtcDateTimeToInstant(DateTime.SpecifyKind(utcDateTime, DateTimeKind.Utc));
        }

        public static Instant DateTimeOffsetToInstant(DateTimeOffset dateTimeOffset)
        {
            return UtcDateTimeToInstant(dateTimeOffset.UtcDateTime);
        }

        public static Instant? DateTimeOffsetToNullableInstant(DateTimeOffset dateTimeOffset)
        {
            return DateTimeOffsetToInstant(dateTimeOffset);
        }

        public static Instant? NullableUtcDateTimeToNullableInstant(DateTime? utcDateTime)
        {
            if (!utcDateTime.HasValue)
                return null;
            return UtcDateTimeAllowingUnspecifiedKindToInstant(utcDateTime.Value);
        }

        public static Instant? NullableDateTimeOffsetToNullableInstant(DateTimeOffset? dateTimeOffset)
        {
            if (!dateTimeOffset.HasValue)
                return null;

            return DateTimeOffsetToInstant(dateTimeOffset.Value);
        }

        public static Instant? UtcDateTimeToNullableInstant(DateTime utcDateTime)
        {
            return UtcDateTimeAllowingUnspecifiedKindToInstant(utcDateTime);
        }

        public static Instant NullableUtcDateTimeToDefaultBeginningOfTimeInstant(DateTime? utcDateTime)
        {
            return utcDateTime.HasValue ? UtcDateTimeAllowingUnspecifiedKindToInstant(utcDateTime.Value) : Instant.MinValue;
        }

        public static Instant NullableUtcDateTimeToDefaultEndOfTimeInstant(DateTime? utcDateTime)
        {
            return utcDateTime.HasValue ? UtcDateTimeAllowingUnspecifiedKindToInstant(utcDateTime.Value) : Instant.MaxValue;
        }

        public static Interval UtcDateTimesAllowingUnspecifiedToInterval(DateTime utcStartTime, DateTime utcEndTime)
        {
            return new Interval(UtcDateTimeAllowingUnspecifiedKindToInstant(utcStartTime),
                UtcDateTimeAllowingUnspecifiedKindToInstant(utcEndTime));
        }

        public static Interval? UtcDateTimesToNullableInterval(DateTime? utcStartTime, DateTime? utcEndTime)
        {
            if (!utcStartTime.HasValue && !utcEndTime.HasValue)
                return null;

            if (utcStartTime.HasValue != utcEndTime.HasValue)
                throw new InvalidOperationException("Both times must be null or non-null");

            return new Interval(UtcDateTimeAllowingUnspecifiedKindToInstant(utcStartTime.Value),
                UtcDateTimeAllowingUnspecifiedKindToInstant(utcEndTime.Value));
        }

        public static Offset HoursToOffset(Int64 utcOffsetInHours)
        {
            return HoursToOffset((double)utcOffsetInHours);
        }

        public static Offset HoursToOffset(double utcOffsetInHours)
        {
            const double minOffsetInHours = -12;
            const double maxOffsetInHours = 14;

            if (utcOffsetInHours < minOffsetInHours || utcOffsetInHours > maxOffsetInHours)
            {
                throw new ArgumentOutOfRangeException("utcOffsetInHours");
            }

            var offsetTicks = TimeSpan.FromHours(utcOffsetInHours).Ticks;

            return Offset.FromTicks(offsetTicks);
        }

        public static Instant Iso8601ToInstant(string value, Iso8601ParseOptions options)
        {
            var result = OffsetDateTimePattern.ExtendedIsoPattern.Parse(value);
            if (result.Success)
                return result.Value.ToInstant();

            if ((options & Iso8601ParseOptions.AllowEndOfTime) != 0
                && value.Equals("MaxInstant", StringComparison.InvariantCultureIgnoreCase))
            {
                return Instant.MaxValue;
            }
            if ((options & Iso8601ParseOptions.AllowBeginningOfTime) != 0
                && value.Equals("MinInstant", StringComparison.InvariantCultureIgnoreCase))
            {
                return Instant.MinValue;
            }

            throw new ArgumentException(string.Format("Failed to parse '{0}'.", value), result.Exception);
        }

        public static DateTimeOffset ToDateTimeOffset(OffsetDateTime offsetDateTime)
        {
            if (offsetDateTime.Equals(MinOffsetDateTime))
                return DateTimeOffset.MinValue;
            if (offsetDateTime.Equals(MaxOffsetDateTime))
                return DateTimeOffset.MaxValue;


            if ((offsetDateTime.LocalDateTime <= MinDateTimeLocalDateTime) ||
                (offsetDateTime.LocalDateTime >= MaxDateTimeLocalDateTime))
                throw new ArgumentOutOfRangeException("offsetDateTime",
                    "Time not within allowable range, MinValue, or MaxValue");

            return offsetDateTime.ToDateTimeOffset();
        }

        public static OffsetDateTime ToOffsetDateTime(Instant instant, Offset offset)
        {
            if (instant == Instant.MinValue)
                return MinOffsetDateTime;
            if (instant == Instant.MaxValue)
                return MaxOffsetDateTime;

            return instant.WithOffset(offset);
        }
    }
}
