using FMS.Web.Shared.Features.Shared;

namespace FMS.Web.Shared.Features.LocationList;

public record LocationFilterVm : PagedQueryBase
{
    public int LocationTypeId { get; set; }
}
