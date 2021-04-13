using System.Collections.Generic;

namespace FMS.Web.Shared
{
    public class PagedResult<T> : PagedResultBase where T : class
    {
        public IList<T> Results { get; set; } = new List<T>();
    }
}
