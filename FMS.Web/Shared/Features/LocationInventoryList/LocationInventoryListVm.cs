namespace FMS.Web.Shared.Features.LocationInventoryList;

public class LocationInventoryListVm
{
    public int ProductBaseId { get; set; }
    public string ProductBaseCode { get; set; } = string.Empty;
    public string ProductBaseName { get; set; } = string.Empty;

    public int LocationId { get; set; }

    public int StockQuantity { get; set; }
    public int ReservedQuantity { get; set; }
    public int FreeQuantity => StockQuantity - ReservedQuantity;
}
