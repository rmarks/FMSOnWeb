namespace FMS.Web.Shared.Features.LocationInventoryList;

public class ProductPriceVm
{
    public int ProductId { get; set; }
    public string ProductCode { get; set; } = string.Empty;

    public decimal UnitPrice { get; set; }
    public string CurrencyCode { get; set; } = string.Empty;

    public int PriceListId { get; set; }
}
