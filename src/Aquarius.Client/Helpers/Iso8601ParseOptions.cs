using System;

namespace Aquarius.Client.Helpers
{
    [Flags]
    public enum Iso8601ParseOptions
    {
        None = 0,
        AllowEndOfTime,
        AllowBeginningOfTime
    }
}
