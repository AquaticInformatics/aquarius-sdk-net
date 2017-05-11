using Aquarius.Helpers;

namespace Aquarius.TimeSeries.Client.EndPoints
{
    public class Provisioning
    {
        public const string EndPoint = Root.EndPoint + "/Provisioning/v1";

        public static string ResolveEndpoint(string host)
        {
            return UriHelper.ResolveEndpoint(host, EndPoint);
        }
    }
}
