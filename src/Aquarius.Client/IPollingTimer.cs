using System;

namespace Aquarius.Client
{
    public interface IPollingTimer
    {
        TimeSpan MaximumElapsedTimeSpan { get; set; }

        void WaitOnePollingInterval();
        void ThrowIfMaximumElapsedTimeSpanExceeded();
    }
}
