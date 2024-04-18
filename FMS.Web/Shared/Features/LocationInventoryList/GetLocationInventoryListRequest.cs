using FMS.Web.Shared.Features.Shared.Paged;
using FMS.Web.Shared.Features.Shared.ProductFilter;

namespace FMS.Web.Shared.Features.LocationInventoryList;

public record GetLocationInventoryListRequest(int LocationId, ProductFilterVm Filter, bool IsLocationNameRequired = false)
{
    public const string RouteTemplate = "api/locationinventory";

    public record Response(string? LocationName, PagedResult<LocationInventoryListVm> PagedInventory);
}
