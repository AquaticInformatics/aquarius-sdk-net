using System;

namespace Aquarius.Helpers
{
    public class UriHelper
    {
        public static Uri ResolveUri(string host, string endpoint, string defaultScheme = null)
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

            uriBuilder.Scheme = defaultScheme ?? Uri.UriSchemeHttp;
            uriBuilder.Host = host;
            uriBuilder.Path = endpoint;

            return uriBuilder.Uri;
        }

        public static string ResolveEndpoint(string host, string endpoint, string defaultScheme = null)
        {
            return ResolveUri(host, endpoint, defaultScheme).ToString();
        }
    }
}
