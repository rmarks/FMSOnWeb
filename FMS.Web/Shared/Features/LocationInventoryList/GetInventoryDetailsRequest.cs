namespace FMS.Web.Shared.Features.LocationInventoryList
{
    public record GetInventoryDetailsRequest(int LocationId, int ProductBaseId)
    {
        public const string RouteTemplate = "api/locationinventory/details";

        public record Response(InventoryDetailsVm InventoryDetails);
    }
}
