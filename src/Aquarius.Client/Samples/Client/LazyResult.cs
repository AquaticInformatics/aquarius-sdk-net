using System.Collections.Generic;

namespace Aquarius.Samples.Client
{
    public class LazyResult<TDomainObject>
    {
        public int TotalCount { get; set; }
        public IEnumerable<TDomainObject> DomainObjects { get; set; }
    }
}
