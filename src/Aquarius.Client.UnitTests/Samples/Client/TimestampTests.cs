using System;
using Aquarius.Samples.Client;
using FluentAssertions;
using NodaTime;
using NUnit.Framework;

namespace Aquarius.UnitTests.Samples.Client
{
    [TestFixture]
    public class TimestampTests
    {
        [Test]
        public void Instant_ImpicitConvertsionToTimestamp_Succeeds()
        {
            var instant = Instant.MinValue;

            Timestamp explicitlyTypedTimestamp = instant;

            explicitlyTypedTimestamp.Value.ShouldBeEquivalentTo(instant);
        }

        [Test]
        public void Timestamp_ImplicitConversionToInstant_WithValidTimeStamp_Succeeds()
        {
            var timestamp = new Timestamp(Instant.MaxValue);

            Instant explicitlyTypedInstant = timestamp;

            explicitlyTypedInstant.ShouldBeEquivalentTo(Instant.MaxValue);
        }

        [Test]
        public void Timestamp_ImplicitConversionToInstant_WithNullTimeStamp_Throws()
        {
            Timestamp timestamp = null;

            Action action = () =>
            {
                // ReSharper disable once ExpressionIsAlwaysNull
                Instant explicitlyTypedInstant = timestamp;
            };

            action.ShouldThrow<NullReferenceException>();
        }
    }
}
