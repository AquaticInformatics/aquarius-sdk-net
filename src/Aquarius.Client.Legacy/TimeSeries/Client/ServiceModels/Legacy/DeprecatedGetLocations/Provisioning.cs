using System.Collections.Generic;
using Aquarius.TimeSeries.Client.ServiceModels.Provisioning;
using ServiceStack;

namespace Aquarius.TimeSeries.Client.ServiceModels.Legacy.DeprecatedGetLocations.Provisioning
{
    public static class First
    {
        // AQ-21049 - GetLocations was removed from Provisioning
        public static readonly AquariusServerVersion Version = AquariusServerVersion.Create("17.2.23");
    }

    [Route("/locations", "GET")]
    public class GetLocations
    : IReturn<LocationsResponse>
    {
    }

    public class LocationsResponse
    {
        public LocationsResponse()
        {
            Results = new List<Location> { };
        }

        ///<summary>
        ///The list of locations
        ///</summary>
        [ApiMember(Description = "The list of locations", DataType = "Array<Location>")]
        public List<Location> Results { get; set; }
    }
}
