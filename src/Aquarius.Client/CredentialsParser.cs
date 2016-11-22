using System;
using System.Linq;

namespace Aquarius.Client
{
    public class CredentialsParser
    {
        private Uri _uri;

        public CredentialsParser(Uri uri)
        {
            ThrowIfNullUri(uri);

            _uri = SanitizeUri(uri);
        }

        public Uri Uri
        {
            get
            {
                return _uri;
            }
            set
            {
                _uri = SanitizeUri(value);
            }
        }

        private static readonly string DefaultScheme = Uri.UriSchemeHttp;
        private static readonly string[] KnownSchemes = { DefaultScheme, Uri.UriSchemeHttps };

        private static Uri SanitizeUri(Uri uri)
        {
            ThrowIfNullUri(uri);

            if (KnownSchemes.Contains(uri.Scheme))
                return uri;

            // Some credentials are passed in as a uri like "user:pass@server", which gets interpreted as an unknown scheme "user:\\pass@server"
            return new Uri(PrefixWithScheme(DefaultScheme, uri.ToString()));
        }

        private static string PrefixWithScheme(string scheme, string suffix)
        {
            return string.Format("{0}{1}{2}", scheme, Uri.SchemeDelimiter, suffix);
        }

        private static void ThrowIfNullUri(Uri uri)
        {
            if (uri != null)
                return;

            throw new ArgumentNullException(nameof(uri));
        }

        public string ServerName
        {
            get
            {
                var serverName = (_uri.Scheme == DefaultScheme)
                    ? _uri.Host
                    : PrefixWithScheme(_uri.Scheme, _uri.Host);

                if (!_uri.IsDefaultPort)
                    serverName += ":" + _uri.Port;

                return serverName;
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentOutOfRangeException(nameof(value));

                var uriText = value;

                if (!KnownSchemes.Any(scheme => uriText.StartsWith(scheme + Uri.SchemeDelimiter)))
                {
                    uriText = PrefixWithScheme(DefaultScheme, uriText);
                }

                Merge(new Uri(uriText));
            }
        }

        public string UserName
        {
            get
            {
                return Uri.UnescapeDataString(new UriBuilder(_uri).UserName);
            }
            set
            {
                if (value == null)
                    throw new ArgumentNullException(nameof(value));


                var builder = new UriBuilder(_uri);

                if (string.IsNullOrEmpty(value))
                {
                    builder.UserName = builder.Password = string.Empty;
                }
                else
                {
                    builder.UserName = Uri.EscapeDataString(value);
                }

                _uri = builder.Uri;
            }
        }

        public string Password
        {
            get
            {
                return Uri.UnescapeDataString(new UriBuilder(_uri).Password);
            }
            set
            {
                if (value == null)
                    throw new ArgumentNullException(nameof(value));

                var builder = new UriBuilder(_uri);

                if (string.IsNullOrEmpty(value))
                {
                    builder.UserName = builder.Password = string.Empty;
                }
                else
                {
                    builder.Password = Uri.EscapeDataString(value);
                }

                _uri = builder.Uri;
            }
        }

        public void Merge(Uri uri)
        {
            var target = new UriBuilder(_uri);
            var source = new UriBuilder(SanitizeUri(uri));

            if (target.Scheme != source.Scheme)
            {
                target.Scheme = source.Scheme;
            }

            if (source.Port > 0 && target.Port != source.Port)
            {
                target.Port = source.Port;
            }

            if (target.Host != source.Host)
            {
                target.Host = source.Host;
            }

            if (!string.IsNullOrEmpty(source.UserName) && (target.UserName != source.UserName))
            {
                target.UserName = source.UserName;
            }

            if (!string.IsNullOrEmpty(source.Password) && (target.Password != source.Password))
            {
                target.Password = source.Password;
            }

            _uri = target.Uri;
        }
    }
}
