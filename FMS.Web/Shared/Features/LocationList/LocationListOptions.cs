using FMS.Web.Shared.Features.Shared;

namespace FMS.Web.Shared.Features.LocationList
{
    public record LocationListOptions : PagedOptionsBase
    {
        public int LocationTypeId { get; set; }
    }
}
