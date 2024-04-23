using FMS.Web.Shared.Features.Shared.Dropdowns;

namespace FMS.Web.Client.Features.Product.ProductBasics;

public class ProductBasicsDropdownsVm
{
    public IEnumerable<DropdownDto> ProductStatuses { get; set; } = default!;
    public IEnumerable<DropdownDto> ProductMaterials { get; set; } = default!;
    public IEnumerable<DropdownDto> ProductSourceTypes { get; set; } = default!;
    public IEnumerable<DropdownDto> ProductDestinationTypes { get; set; } = default!;
    public IEnumerable<DropdownDto> ProductTypes { get; set; } = default!;
    public IEnumerable<DropdownDto> ProductGroups { get; set; } = default!;
    public IEnumerable<DropdownDto> ProductBrands { get; set; } = default!;
    public IEnumerable<DropdownDto> ProductCollections { get; set; } = default!;

    public IEnumerable<DropdownDto> GetFilteredProductGroups(int productTypeId)
    {
        if (productTypeId > 0)
        {
            return ProductGroups.Where(p => p.ParentId == productTypeId).ToList();
        }

        return Enumerable.Empty<DropdownDto>();
    }

    public IEnumerable<DropdownDto> GetFilteredProductCollections(int productBrandId)
    {
        if (productBrandId > 0)
        {
            return ProductCollections.Where(p => p.ParentId == productBrandId).ToList();
        }

        return Enumerable.Empty<DropdownDto>();
    }
}
