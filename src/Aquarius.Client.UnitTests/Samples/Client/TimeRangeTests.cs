using System;
using Aquarius.Samples.Client.ServiceModel;
using FluentAssertions;
using NodaTime;
using NUnit.Framework;

namespace Aquarius.UnitTests.Samples.Client
{
    [TestFixture]
    public class TimeRangeTests
    {
        [Test]
        public void DefaultCtor_IsValid()
        {
            var timeRange = new TimeRange();

            timeRange.StartTime.Should().BeNull();
            timeRange.EndTime.Should().BeNull();
            timeRange.HasInterval().ShouldBeEquivalentTo(false);
        }

        [Test]
        public void Ctor_WithOnlyStartTime_IsValid()
        {
            var timeRange = new TimeRange {StartTime = Instant.MinValue};

            timeRange.StartTime.Should().NotBeNull();
            timeRange.EndTime.Should().BeNull();
            timeRange.HasInterval().ShouldBeEquivalentTo(false);
        }

        [Test]
        public void Ctor_WithOnlyEndTime_IsValid()
        {
            var timeRange = new TimeRange { EndTime = Instant.MinValue };

            timeRange.StartTime.Should().BeNull();
            timeRange.EndTime.Should().NotBeNull();
            timeRange.HasInterval().ShouldBeEquivalentTo(false);
        }

        [Test]
        public void Ctor_WithStartTimePreceedingEndTime_IsValid()
        {
            var timeRange = new TimeRange { StartTime = Instant.MinValue, EndTime = Instant.MinValue.PlusTicks(1) };

            timeRange.HasInterval().ShouldBeEquivalentTo(true);
            timeRange.Interval().Duration.BclCompatibleTicks.ShouldBeEquivalentTo(1);
        }

        [Test]
        public void Ctor_WithIdenticalStartAndEndTimes_Throws()
        {
            // ReSharper disable once ObjectCreationAsStatement
            Action action = () => new TimeRange { StartTime = Instant.MinValue, EndTime = Instant.MinValue };

            action.ShouldThrow<ArgumentException>();
        }
    }
}
