using NodaTime;

namespace Aquarius.Client.UnitTests.TestHelpers
{
    public static class NodaTimeHelpers
    {
        public static Duration DurationFromDays(long days)
        {
#if NODATIME2
            return Duration.FromDays(days);
#else
            return Duration.FromStandardDays(days);
#endif
        }

        public static long Ticks(this Duration duration)
        {
#if NODATIME2
            return duration.BclCompatibleTicks;
#else
            return duration.Ticks;
#endif
        }

        public static Instant InstantFromUnixTimeTicks(long ticks)
        {
#if NODATIME2
            return Instant.FromUnixTimeTicks(ticks);
#else
            return Instant.FromTicksSinceUnixEpoch(ticks);
#endif
        }
    }
}
