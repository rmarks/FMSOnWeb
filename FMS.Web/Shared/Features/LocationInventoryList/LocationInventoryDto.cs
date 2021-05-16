using FMS.Web.Shared.Features.Shared;

namespace FMS.Web.Shared.Features.LocationInventoryList
{
    public class LocationInventoryDto
    {
        public string LocationName { get; set; }
        public PagedResult<LocationInventoryListDto> PagedInventory { get; set; }
    }
}
