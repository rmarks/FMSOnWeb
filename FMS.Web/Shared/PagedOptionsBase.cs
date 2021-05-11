namespace FMS.Web.Shared
{
    public record PagedOptionsBase
    {
        public int CurrentPage { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }
}
