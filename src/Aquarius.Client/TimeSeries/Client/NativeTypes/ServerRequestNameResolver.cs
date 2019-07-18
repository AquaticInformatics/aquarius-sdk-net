using System;
using System.Collections.Generic;
using ServiceStack;

namespace Aquarius.TimeSeries.Client.NativeTypes
{
    public class ServerRequestNameResolver
    {
        private readonly object _syncLock = new object();

        private Dictionary<string, MetadataType> RequestsByRoute { get; set; }

        public string ResolveRequestName<TRequest>(IServiceClient client, TRequest request)
        {
            FetchEndpointMetadataOnce(client);

            var requestMetadata = FindMetadataType(request);

            if (requestMetadata == null)
                return typeof(TRequest).Name;

            return requestMetadata.Name;
        }

        private void FetchEndpointMetadataOnce(IServiceClient client)
        {
            lock (_syncLock)
            {
                if (RequestsByRoute != null)
                    return;

                RequestsByRoute = new Dictionary<string, MetadataType>(StringComparer.InvariantCultureIgnoreCase);

                try
                {
                    var response = client.Get(new GetTypesMetadata());

                    foreach (var operation in response.Operations)
                    {
                        foreach (var route in operation.Request.Routes)
                        {
                            RequestsByRoute[route.Path] = operation.Request;
                        }
                    }
                }
                catch (WebServiceException)
                {
                    // The endpoint may be private and not have metadata exposed.
                    // So all we can do is hope that the client request name still matches the server name
                }
            }
        }

        private MetadataType FindMetadataType<TRequest>(TRequest request)
        {
            var route = request
                .ToRelativeUri(HttpMethods.Get)
                .Split('?')[0];

            if (RequestsByRoute.TryGetValue(route, out var metadataType))
                return metadataType;

            return null;
        }
    }
}
