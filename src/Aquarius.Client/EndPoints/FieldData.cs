namespace Aquarius.Client.EndPoints
{
    public class FieldData
    {
        public const string EndPoint = Root.EndPoint + "/apps/v1";

        public static string ResolveEndpoint(string host)
        {
            return UriHelper.ResolveEndpoint(host, EndPoint);
        }
    }
}
