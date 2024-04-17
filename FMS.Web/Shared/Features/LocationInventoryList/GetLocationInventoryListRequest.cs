using FMS.Web.Shared.Features.Shared;

namespace FMS.Web.Shared.Features.LocationInventoryList;

public record GetLocationInventoryListRequest(int LocationId, InventoryListFilterVm Filter, bool IsLocationNameRequired = false)
{
    public const string RouteTemplate = "api/locationinventory";

    public record Response(string? LocationName, PagedResult<LocationInventoryListVm> PagedInventory);
}
