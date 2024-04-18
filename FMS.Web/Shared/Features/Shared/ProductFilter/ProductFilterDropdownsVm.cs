using FMS.Web.Shared.Features.Shared.Dropdowns;

namespace FMS.Web.Shared.Features.Shared.ProductFilter;

public class ProductFilterDropdownsVm
{
    public IEnumerable<DropdownVm> ProductStatuses { get; set; } = default!;
    public IEnumerable<DropdownVm> ProductMaterials { get; set; } = default!;
    public IEnumerable<DropdownVm> ProductSourceTypes { get; set; } = default!;
    public IEnumerable<DropdownVm> ProductDestinationTypes { get; set; } = default!;
    public IEnumerable<DropdownVm> ProductTypes { get; set; } = default!;
    public IEnumerable<ChildDropdownVm> ProductGroups { get; set; } = default!;
    public IEnumerable<DropdownVm> ProductBrands { get; set; } = default!;
    public IEnumerable<ChildDropdownVm> ProductCollections { get; set; } = default!;

    public IEnumerable<ChildDropdownVm> GetFilteredProductGroups(int? productTypeId)
    {
        if (productTypeId > 0)
        {
            return ProductGroups.Where(p => p.ParentId == productTypeId).ToList();
        }

        return Enumerable.Empty<ChildDropdownVm>();
    }

    public IEnumerable<ChildDropdownVm> GetFilteredProductCollections(int? productBrandId)
    {
        if (productBrandId > 0)
        {
            return ProductCollections.Where(p => p.ParentId == productBrandId).ToList();
        }

        return Enumerable.Empty<ChildDropdownVm>();
    }
}
