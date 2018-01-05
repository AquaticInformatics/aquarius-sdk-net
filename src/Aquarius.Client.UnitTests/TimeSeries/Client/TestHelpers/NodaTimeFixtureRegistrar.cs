using System;
using FluentAssertions;
using FluentAssertions.Equivalency;
using NodaTime;
using Ploeh.AutoFixture;

namespace Aquarius.UnitTests.TimeSeries.Client.TestHelpers
{
    public static class NodaTimeFixtureRegistrar
    {
        internal const int MinOffsetHours = -12;
        internal const int MaxOffsetHours = +14;
        internal const int OffsetHoursModulus = MaxOffsetHours - MinOffsetHours + 1;

        private static readonly Instant BaseInstant = GetBaseInstant();
        private static readonly Fixture Fixture = new Fixture();

        private static readonly Duration SmallestVisibleDurationInVisualStudioDebugger = Duration.FromMilliseconds(1);

        private static Instant GetBaseInstant()
        {
            return Instant.FromUnixTimeTicks(0);
        }

        private static readonly Duration BaseDuration = GetBaseDuration();

        private static Duration GetBaseDuration()
        {
            var longestDurationRepresentedByInt32 = Duration.FromTicks(Int32.MaxValue);
            var secondsInLogestDuration = longestDurationRepresentedByInt32.BclCompatibleTicks / Duration.FromSeconds(1).BclCompatibleTicks;
            var durationNotRepresentableByInt32 = Duration.FromSeconds(secondsInLogestDuration + 1);
            return durationNotRepresentableByInt32;
        }

        public static void RegisterNodaTimeTypes(IFixture fixture)
        {
            fixture.Register(() => CreateTimeZoneOffset(fixture));
            fixture.Register(() => CreateInstant(fixture));
            fixture.Register(() => CreateDuration(fixture));
            fixture.Register(() => CreateInterval(fixture));
            //fixture.Register(() => CreateTimeRange(fixture));
            fixture.Register(() => CreateOffsetDateTime(fixture));
        }

        private static Offset CreateTimeZoneOffset(IFixture fixture)
        {
            var offsetHours = Math.Abs(fixture.Create<int>()) % OffsetHoursModulus + MinOffsetHours;
            return Offset.FromHours(offsetHours);
        }

        private static Instant CreateInstant(IFixture fixture)
        {
            var someDuration = SmallestVisibleDurationInVisualStudioDebugger * fixture.Create<Int64>();
            return BaseInstant + someDuration;
        }

        private static Duration CreateDuration(IFixture fixture)
        {
            return BaseDuration * fixture.Create<Int64>();
        }

        private static Interval CreateInterval(IFixture fixture)
        {
            var start = fixture.Create<Instant>();
            var duration = fixture.Create<Duration>();
            var end = start.Plus(duration);
            return new Interval(start, end);
        }

        /*
        private static TimeRange CreateTimeRange(IFixture fixture)
        {
            return new TimeRange(fixture.Create<Interval>());
        }
        */
        private static OffsetDateTime CreateOffsetDateTime(IFixture fixture)
        {
            var instant = fixture.Create<Instant>();
            var offset = fixture.Create<Offset>();
            return instant.WithOffset(offset);
        }

        public static EquivalencyAssertionOptions<T> GetAssertionOptions<T>(EquivalencyAssertionOptions<T> options)
        {
            return options.Using<Interval>(c => c.Subject.Equals(c.Expectation).Should().BeTrue())
                .WhenTypeIs<Interval>()
                .Using<OffsetDateTime>(c => c.Subject.Should().Be(c.Expectation))
                .WhenTypeIs<OffsetDateTime>();
        }

        public static void RegisterUtcDateTime(IFixture fixture)
        {
            fixture.Customize<DateTime>(composer => composer.FromFactory(CreateUtcDateTime));
        }

        private static DateTime CreateUtcDateTime()
        {
            var dateTime = Fixture.Create<DateTime>();
            return DateTime.SpecifyKind(dateTime, DateTimeKind.Utc);
        }
    }
}
