namespace FMS.Web.Shared.Options
{
    public record LocationListOptions : PagedOptionsBase
    {
        public int LocationTypeId { get; set; }
    }
}
