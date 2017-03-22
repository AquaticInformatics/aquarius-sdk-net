namespace Aquarius.TimeSeries.Client.EndPoints
{
    public class PublishV2
    {
        public const string EndPoint = Root.EndPoint + "/Publish/v2";

        public static string ResolveEndpoint(string host)
        {
            return UriHelper.ResolveEndpoint(host, EndPoint);
        }
    }
}
