using FMS.Web.Shared.Features.Shared;

namespace FMS.Web.Shared.Features.LocationList
{
    public record LocationListRequest(LocationFilterOptions Options)
    {
        public record Response(PagedResult<LocationListDto> PagedLocations);
    }
}
