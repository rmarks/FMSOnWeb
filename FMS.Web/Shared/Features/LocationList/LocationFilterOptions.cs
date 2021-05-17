using FMS.Web.Shared.Features.Shared;

namespace FMS.Web.Shared.Features.LocationList
{
    public record LocationFilterOptions : PagedOptionsBase
    {
        public int LocationTypeId { get; set; }
    }
}
