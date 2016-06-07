namespace Aquarius.Client.EndPoints
{
    public class LegacyDataService
    {
        public const string EndPoint = Root.EndPoint + "/AquariusDataService.svc";

        public static string ResolveEndpoint(string host)
        {
            return UriHelper.ResolveEndpoint(host, EndPoint);
        }
    }
}
