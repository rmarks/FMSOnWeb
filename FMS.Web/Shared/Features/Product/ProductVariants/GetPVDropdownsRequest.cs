using FMS.Web.Shared.Features.Shared.Dropdowns;

namespace FMS.Web.Shared.Features.Product.ProductVariants;

public record GetPVDropdownsRequest
{
    public const string RouteTemplate = "/api/products/variants/dropdowns";

    public record Response(IEnumerable<DropdownVm> ProductVariantTypes);
}
