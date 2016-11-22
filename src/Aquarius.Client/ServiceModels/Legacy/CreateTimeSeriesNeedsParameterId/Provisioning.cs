namespace Aquarius.Client.ServiceModels.Legacy.CreateTimeSeriesNeedsParameterId.Provisioning
{
    public static class First
    {
        // AQ-19419: Older Provisioning API needs to send parameter.Identifier ("Stage") instead of parameter.ID ("HG") when creating a time-series
        public static readonly AquariusServerVersion Version = AquariusServerVersion.Create("16.2.49");
    }
}
