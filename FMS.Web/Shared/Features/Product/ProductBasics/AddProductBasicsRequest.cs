namespace FMS.Web.Shared.Features.Product.ProductBasics;

public record AddProductBasicsRequest(ProductBasicsDto ProductBasics)
{
    public const string RouteTemplate = "/api/products/basics";

    public record Response(int Id);
}
