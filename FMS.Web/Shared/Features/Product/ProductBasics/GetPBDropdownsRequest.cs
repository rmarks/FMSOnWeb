using FMS.Web.Shared.Features.Shared.Dropdowns;

namespace FMS.Web.Shared.Features.Product.ProductBasics;

public record GetPBDropdownsRequest()
{
    public const string RouteTemplate = "api/products/basics/dropdowns";
    public record Response(IDictionary<string, IEnumerable<DropdownDto>> Dropdowns);
}
