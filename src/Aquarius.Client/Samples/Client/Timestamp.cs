using NodaTime;
using ServiceStack.Text.Common;

namespace Aquarius.Samples.Client
{
    // Duplicates functionality of DomainDateTime.java
    // Not quite the same as a NodaTime.Instant, which is a struct and cannot be null. A Timestamp can be null.
    // But the Timestamp class is implicitly convertable to/from an Instant
    public class Timestamp
    {
        public static implicit operator Instant(Timestamp timestamp)
        {
            return timestamp.Value;
        }

        public static implicit operator Timestamp(Instant instant)
        {
            return new Timestamp(instant);
        }

        public Timestamp(Instant value)
        {
            Value = value;
        }

        public Instant Value { get; }

        public override string ToString()
        {
            return DateTimeSerializer.ToXsdDateTimeString(Value.ToDateTimeUtc());
        }
    }
}
