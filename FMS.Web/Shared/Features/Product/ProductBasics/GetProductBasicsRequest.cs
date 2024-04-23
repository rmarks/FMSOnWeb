namespace FMS.Web.Shared.Features.Product.ProductBasics;

public record GetProductBasicsRequest(int Id)
{
    public const string RouteTemplate = "/api/products/basics/{Id}";
    public record Response(ProductBasicsDto ProductBasics);
}
