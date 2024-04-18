namespace FMS.Web.Shared.Features.Shared.Paged;

public class PagedResult<T> : PagedResultBase where T : class
{
    public IList<T> List { get; set; } = default!;
}
