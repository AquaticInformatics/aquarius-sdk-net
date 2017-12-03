using System;
using NodaTime;


// ReSharper disable once CheckNamespace
namespace Aquarius.Samples.Client.ServiceModel
{
    // Duplicates functionality of DomainDateTimeRange.java
    // Not quite the same as a NodaTime.Interval (which requires both start and end to exist)
    public class TimeRange
    {
        public Instant? StartTime
        {
            get => _startTime;
            set
            {
                ThrowIfNotValid(value, _endTime);
                _startTime = value;
                
            }
        }

        public Instant? EndTime
        {
            get => _endTime;
            set
            {
                ThrowIfNotValid(_startTime, value);
                _endTime = value;
            } 
        }

        private Instant? _startTime;
        private Instant? _endTime;

        private static void ThrowIfNotValid(Instant? startTime, Instant? endTime)
        {
            if( startTime == null || endTime == null || endTime.Value > startTime.Value )
                return;

            throw new ArgumentException($"Invalid time range: '{startTime.Value}' must preceed '{endTime.Value}'.");
        }

        public bool HasInterval()
        {
            return StartTime.HasValue && EndTime.HasValue;
        }

        public Interval Interval()
        {
            if (!StartTime.HasValue || !EndTime.HasValue)
                throw new ArgumentException($"Time-range has no interval: StartTime={StartTime} EndTime={EndTime}");

            return new Interval(StartTime.Value, EndTime.Value);
        }
    }
}
