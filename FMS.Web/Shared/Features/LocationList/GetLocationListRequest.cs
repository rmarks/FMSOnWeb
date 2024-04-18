using FMS.Web.Shared.Features.Shared.Paged;

namespace FMS.Web.Shared.Features.LocationList;

public record GetLocationListRequest(LocationFilterVm Filter)
{
    public record Response(PagedResult<LocationListVm> PagedLocations);
}
