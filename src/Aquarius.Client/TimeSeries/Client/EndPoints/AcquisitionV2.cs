namespace Aquarius.TimeSeries.Client.EndPoints
{
    public class AcquisitionV2
    {
        public const string EndPoint = Root.EndPoint + "/Acquisition/v2";

        public static string ResolveEndpoint(string host)
        {
            return UriHelper.ResolveEndpoint(host, EndPoint);
        }
    }
}
