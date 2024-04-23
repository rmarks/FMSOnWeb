using FMS.Web.Shared.Features.Shared.Dropdowns;

namespace FMS.Web.Client.Features.Product.ProductVariants;

public class ProductVariantsDropdownsVm
{
    public IEnumerable<DropdownVm> ProductVariantTypes { get; set; } = default!;
}
