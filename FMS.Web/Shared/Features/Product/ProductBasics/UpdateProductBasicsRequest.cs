namespace FMS.Web.Shared.Features.Product.ProductBasics;

public record UpdateProductBasicsRequest(ProductBasicsDto ProductBasics)
{
    public int Id { get; init; }

    public const string RouteTemplate = "/api/products/basics/{Id}";
}
