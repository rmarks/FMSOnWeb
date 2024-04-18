namespace FMS.Web.Shared.Features.Shared.Paged;

public record PagedQueryBase
{
    public int CurrentPage { get; set; } = 1;
    public int PageSize { get; set; } = 10;
}
