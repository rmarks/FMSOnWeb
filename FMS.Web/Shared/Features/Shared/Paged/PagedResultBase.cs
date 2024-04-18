namespace FMS.Web.Shared.Features.Shared.Paged;

public abstract class PagedResultBase
{
    public int CurrentPage { get; set; }
    public int PageCount { get; set; }
    public int PageSize { get; set; }
    public int ItemCount { get; set; }
}
