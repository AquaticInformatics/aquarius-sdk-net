using System;
using System.Collections.Generic;
using System.Linq;
using Aquarius.Helpers;
using ServiceStack;

namespace Aquarius.Samples.Client
{
    public class SamplesServiceClient : SdkServiceClient
    {
        public SamplesServiceClient(string baseUri)
            : base(baseUri)
        {
        }

        public override string ResolveTypedUrl(string httpMethod, object requestDto)
        {
            var typedUrl = base.ResolveTypedUrl(httpMethod, requestDto);

            if (!httpMethod.Equals(HttpMethods.Get, StringComparison.InvariantCultureIgnoreCase))
                return typedUrl;

            return CreateGetRequestUrlWithoutJsvParameters(typedUrl);
        }

        // Since AQUARIUS Samples is not a ServiceStack-based back-end, it does not support JSV formatting for its GET parameters.
        // Instead, when a request DTO contains a property that is a collection, the URL generated will need to account for that.
        private string CreateGetRequestUrlWithoutJsvParameters(string absoluteUrl)
        {
            var uri = new UriBuilder(absoluteUrl);

            var query = uri.Query;

            if (string.IsNullOrEmpty(query) || query == "?")
                return absoluteUrl;

            query = query.Substring(1);

            uri.Query = string.Empty;

            var parameters = new List<Tuple<string, string>>();

            foreach (var param in query.Split(ParameterSeparators, StringSplitOptions.RemoveEmptyEntries))
            {
                var components = param.Split(KeyValueSeparators, 2);

                if (components.Length < 2)
                    continue;

                var name = components[0];
                var value = components[1];

                if (!value.StartsWith(JsvArrayStart) && !value.EndsWith(JsvArrayEnd))
                {
                    parameters.Add(new Tuple<string, string>(name, value));
                    continue;
                }

                var values = value.Substring(JsvArrayStart.Length,
                    value.Length - (JsvArrayStart.Length + JsvArrayEnd.Length))
                    ;

                if (string.IsNullOrEmpty(values))
                    continue;

                parameters.Add(new Tuple<string, string>(name, values));
            }

            uri.Query = string.Join("&", parameters.Select(p => $"{p.Item1}={p.Item2}"));

            return uri.ToString();
        }

        private const string JsvArrayStart = "%5B";
        private const string JsvArrayEnd = "%5D";
        private static readonly char[] ParameterSeparators = {'&'};
        private static readonly char[] KeyValueSeparators = {'='};
    }
}
