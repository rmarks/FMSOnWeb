namespace FMS.Web.Shared.Dtos
{
    public class LocationInventoryDto
    {
        public string LocationName { get; set; }
        public PagedResult<LocationInventoryListDto> PagedInventory { get; set; }
    }
}
