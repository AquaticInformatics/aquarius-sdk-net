using System.Collections.Generic;
using Aquarius.Client.ServiceModels.Provisioning;
using ServiceStack;

namespace Aquarius.Client.ServiceModels.Legacy.ResponseLists.Provisioning
{
    public static class First
    {
        // AQ-20562: Older Provisioning API returned an anonymous list of results, instead of a response DTO with List<T> Results property
        public static readonly AquariusServerVersion Version = AquariusServerVersion.Create("16.3.69");
    }

    [Route("/parameters", "GET")]
    public class GetParameters
    : IReturn<List<Parameter>>
    {
    }

    [Route("/monitoringmethods", "GET")]
    public class GetMonitoringMethods
        : IReturn<List<MonitoringMethod>>
    {
    }

    [Route("/locations", "GET")]
    public class GetLocations
        : IReturn<List<Location>>
    {
    }
}
