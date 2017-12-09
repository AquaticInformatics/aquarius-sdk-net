namespace Aquarius.TimeSeries.Client.ServiceModels.Legacy.ReplaceToEndOfTime.Acquisition
{
    public static class First
    {
        // AQ-19300: Older Acquisiton API does not support Instant.MaxValue as an Interval.End for overwrite appends
        public static readonly AquariusServerVersion Version = AquariusServerVersion.Create("16.3");
    }
}
