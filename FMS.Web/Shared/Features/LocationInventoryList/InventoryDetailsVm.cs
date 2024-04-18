namespace FMS.Web.Shared.Features.LocationInventoryList;

public class InventoryDetailsVm
{
    public LocationInventoryListVm? ProductBaseInventory { get; set; }

    public IList<ProductPriceVm> ProductPrices { get; set; } = default!;
}
