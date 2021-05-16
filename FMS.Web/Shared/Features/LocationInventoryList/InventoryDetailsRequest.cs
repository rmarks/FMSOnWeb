namespace FMS.Web.Shared.Features.LocationInventoryList
{
    public record InventoryDetailsRequest(int LocationId, int ProductBaseId)
    {
        public record Response(InventoryDetailsDto InventoryDetails);
    }
}
