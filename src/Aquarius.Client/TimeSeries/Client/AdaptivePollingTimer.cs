using System;
using System.Diagnostics;
using System.Threading;

namespace Aquarius.TimeSeries.Client
{
    public class AdaptivePollingTimer : IPollingTimer
    {
        public TimeSpan MaximumElapsedTimeSpan { get; set; }
        public TimeSpan MaximumPollInterval { get; set; }

        private readonly CancellationToken? _cancellationToken;
        private readonly Stopwatch _stopwatch;
        private TimeSpan _nextPollInterval;

        public AdaptivePollingTimer(TimeSpan? maximumElapsedTimeSpan = null, CancellationToken? cancellationToken = null)
        {
            _cancellationToken = cancellationToken;
            MaximumElapsedTimeSpan = maximumElapsedTimeSpan ?? TimeSpan.FromMinutes(5);
            MaximumPollInterval = TimeSpan.FromMinutes(1);

            _nextPollInterval = TimeSpan.FromMilliseconds(50);
            _stopwatch = Stopwatch.StartNew();
        }

        public void WaitOnePollingInterval()
        {
            _nextPollInterval = _nextPollInterval.Ticks < MaximumPollInterval.Ticks
                ? TimeSpan.FromTicks((3 * _nextPollInterval.Ticks) / 2)
                : MaximumPollInterval;

            if (!_cancellationToken.HasValue)
            {
                Thread.Sleep(_nextPollInterval);
                return;
            }

            _cancellationToken.Value.WaitHandle.WaitOne(_nextPollInterval);
            _cancellationToken.Value.ThrowIfCancellationRequested();
        }

        public void ThrowIfMaximumElapsedTimeSpanExceeded()
        {
            if (_stopwatch.Elapsed < MaximumElapsedTimeSpan)
                return;

            throw new TimeoutException(string.Format("Poll operating exceeded TimeSpan={0}", MaximumElapsedTimeSpan));
        }
    }
}
