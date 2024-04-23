namespace FMS.Web.Shared.Features.Product.ProductPrices;

public record GetProductPricesRequest(int ProductBaseId, int PriceListId)
{
    public const string RouteTemplate = "/api/products/prices/productbase/{ProductBaseId}/pricelist/{PriceListId}";

    public record Response(IEnumerable<ProductPriceDto> ProductPrices);
    public record ProductPriceDto(
        int Id, 
        int ProductId, 
        string ProductCode, 
        decimal UnitPrice, 
        int PriceListId);
}
