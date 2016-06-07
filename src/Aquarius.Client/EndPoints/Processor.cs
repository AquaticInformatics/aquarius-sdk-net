namespace Aquarius.Client.EndPoints
{
    public class Processor
    {
        public const string EndPoint = Root.EndPoint + "/Processor";

        public static string ResolveEndpoint(string host)
        {
            return UriHelper.ResolveEndpoint(host, EndPoint);
        }
    }
}
