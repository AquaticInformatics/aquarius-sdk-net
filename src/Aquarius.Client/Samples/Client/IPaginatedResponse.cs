using System.Collections.Generic;

namespace Aquarius.Samples.Client
{
    public interface IPaginatedResponse<TDomainObject>
    {
        int TotalCount { get; set; }
        string Cursor { get; set; }
        List<TDomainObject> DomainObjects { get; set; }
    }
}
