using FMS.Web.Shared.Features.Shared;

namespace FMS.Web.Shared.Features.LocationInventoryList
{
    public record LocationInventoryListRequest(int LocationId, InventoryFilterOptions Options, bool IsFirstRequest = false)
    {
        public record Response(string LocationName, PagedResult<LocationInventoryListDto> PagedInventory);
    }
}
