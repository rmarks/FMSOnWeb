using FMS.Web.Shared.Features.Shared.Dropdowns;

namespace FMS.Web.Client.Features.Product.ProductPrices;

public class ProductPricesDropdownsVm
{
    public IEnumerable<DropdownVm> PriceLists { get; set; } = default!;
}
