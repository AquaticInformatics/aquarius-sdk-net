using System;

namespace Aquarius.TimeSeries.Client.EndPoints
{
    public class UriHelper
    {
        public static Uri ResolveUri(string host, string endpoint)
        {
            var uriBuilder = new UriBuilder();
            Uri uri;

            if (Uri.TryCreate(host, UriKind.RelativeOrAbsolute, out uri))
            {
                if (uri.IsAbsoluteUri)
                {
                    uriBuilder.Scheme = uri.Scheme;
                    uriBuilder.Host = uri.Host;
                    uriBuilder.Port = uri.Port;
                    uriBuilder.Path = endpoint;

                    return uriBuilder.Uri;
                }
            }

            uriBuilder.Scheme = Uri.UriSchemeHttp;
            uriBuilder.Host = host;
            uriBuilder.Path = endpoint;

            return uriBuilder.Uri;
        }

        public static string ResolveEndpoint(string host, string endpoint)
        {
            return ResolveUri(host, endpoint).ToString();
        }
    }
}
