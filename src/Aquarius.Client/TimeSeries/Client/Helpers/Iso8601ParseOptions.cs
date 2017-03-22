using System;

namespace Aquarius.TimeSeries.Client.Helpers
{
    [Flags]
    public enum Iso8601ParseOptions
    {
        None = 0,
        AllowEndOfTime,
        AllowBeginningOfTime
    }
}
