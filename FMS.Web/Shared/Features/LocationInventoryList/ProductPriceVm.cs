namespace FMS.Web.Shared.Features.LocationInventoryList;

public class ProductPriceVm
{
    public int ProductId { get; set; }
    public string ProductCode { get; set; }

    public decimal UnitPrice { get; set; }
    public string CurrencyCode { get; set; }

    public int PriceListId { get; set; }
}
