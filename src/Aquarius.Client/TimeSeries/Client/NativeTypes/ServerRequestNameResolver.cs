using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using ServiceStack;

namespace Aquarius.TimeSeries.Client.NativeTypes
{
    public class ServerRequestNameResolver
    {
        private readonly object _syncLock = new object();

        private ConcurrentDictionary<string, MetadataType> RequestsByRoute { get; set; }
        private ConcurrentDictionary<Type, List<RestRoute>> RoutesByType { get; } = new ConcurrentDictionary<Type, List<RestRoute>>();

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
            if (RequestsByRoute != null)
                return;

            lock (_syncLock)
            {
                if (RequestsByRoute != null)
                    return;

                RequestsByRoute = new ConcurrentDictionary<string, MetadataType>(StringComparer.InvariantCultureIgnoreCase);

                try
                {
                    var response = client.Get(new GetTypesMetadata());

                    foreach (var operation in response.Operations)
                    {
                        var routes = operation.Routes ?? operation.Request.Routes;

                        if (routes == null)
                            continue;

                        foreach (var route in routes)
                        {
                            RequestsByRoute[route.Path] = operation.Request;
                        }
                    }
                }
                catch (Exception)
                {
                    // The endpoint may be private and not have metadata exposed.
                    // Or the shape of the types metadata may have changed so much that other errors occur.
                    // So all we can do is hope that the client request name still matches the server name
                }
            }
        }

        private static List<RestRoute> GetRoutesForType(Type requestType)
        {
            var restRoutes = requestType.AllAttributes<RouteAttribute>()
                .Select(attr => new RestRoute(requestType, attr.Path, attr.Verbs, attr.Priority))
                .ToList();

            return restRoutes;
        }

        private MetadataType FindMetadataType<TRequest>(TRequest request)
        {
            var requestType = request.GetType();

            var routes = RoutesByType.GetOrAdd(requestType, GetRoutesForType);

            if (!routes.Any())
                throw new InvalidOperationException($"No routes found for '{requestType.Name}' request");

            var httpMethod = routes.First().HttpMethods.First();

            var route = request
                .ToRelativeUri(httpMethod)
                .Split('?')[0];

            if (RequestsByRoute.TryGetValue(route, out var metadataType))
                return metadataType;

            return null;
        }
    }
}
