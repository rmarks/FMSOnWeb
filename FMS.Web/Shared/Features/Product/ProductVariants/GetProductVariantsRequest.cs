namespace FMS.Web.Shared.Features.Product.ProductVariants;

public record GetProductVariantsRequest(int Id)
{
    public const string RouteTemplate = "/api/products/variants/{id}";

    public record Response(int Id, int? ProductVariantTypeId, IEnumerable<ProductDto> Products);
    public record ProductDto(int Id, string Code, string Name, int ProductBaseId);
}
