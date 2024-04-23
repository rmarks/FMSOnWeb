namespace FMS.Web.Client.Features.Product.ProductPrices;

public record ProductPriceVm
{
    public int Id { get; set; }
    public int ProductId { get; set; }
    public string ProductCode { get; set; } = string.Empty;
    public decimal UnitPrice { get; set; }
    public int PriceListId { get; set; }
}
