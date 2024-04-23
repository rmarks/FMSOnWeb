using FMS.Web.Shared.Features.Shared.Dropdowns;

namespace FMS.Web.Shared.Features.Product.ProductPrices;

public record GetPPDropdownsRequest
{
    public const string RouteTemplate = "/api/products/prices/dropdowns";

    public record Response(IEnumerable<DropdownVm> PriceLists);
}
