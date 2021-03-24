using System.Collections.Generic;
using ServiceStack;

namespace Aquarius.TimeSeries.Client.NativeTypes
{
    // Lifted from ServiceStack\src\ServiceStack.Common\MetadataTypes.cs to avoid having to bring in the full server-side assembly
    [Route("/types/metadata", HttpMethods.Get)]
    public class GetTypesMetadata : IReturn<MetadataTypes>
    {
    }

    // Trimmed down to a small subset of properties necessary to resolve the server-side name of a request by its route
    public class MetadataTypes
    {
        public List<MetadataOperationType> Operations { get; set; }
    }

    public class MetadataOperationType
    {
        public List<string> Actions { get; set; }
        public MetadataType Request { get; set; }
        public List<MetadataRoute> Routes { get; set; }
    }

    public class MetadataType
    {
        public string Name { get; set; }

        public List<MetadataRoute> Routes { get; set; }
    }

    public class MetadataRoute
    {
        public string Path { get; set; }
        public string Verbs { get; set; }
        public string Notes { get; set; }
        public string Summary { get; set; }
    }
}
