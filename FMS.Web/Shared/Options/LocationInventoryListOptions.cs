namespace FMS.Web.Shared.Options
{
    public class LocationInventoryListOptions : PagedOptionsBase
    {
        public int ProductSourceTypeId { get; set; }
        public int ProductGroupId { get; set; }
    }
}
