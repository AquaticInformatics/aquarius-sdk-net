using System;

namespace Aquarius.TimeSeries.Client
{
    public interface IPollingTimer
    {
        TimeSpan MaximumElapsedTimeSpan { get; set; }

        void WaitOnePollingInterval();
        void ThrowIfMaximumElapsedTimeSpanExceeded();
    }
}
