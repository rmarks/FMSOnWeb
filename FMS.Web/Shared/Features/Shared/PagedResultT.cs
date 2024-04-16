using System.Collections.Generic;

namespace FMS.Web.Shared.Features.Shared;

public class PagedResult<T> : PagedResultBase where T : class
{
    public IList<T> List { get; set; }
}
