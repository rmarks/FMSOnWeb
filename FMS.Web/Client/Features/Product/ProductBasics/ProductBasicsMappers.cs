using FMS.Web.Shared.Features.Shared.Dropdowns;

namespace FMS.Web.Client.Features.Product.ProductBasics;

public static class ProductBasicsMappers
{
    public static void MapFromDictionary(this ProductBasicsDropdownsVm vm, IDictionary<string, IEnumerable<DropdownDto>> dict)
    {
        vm.ProductStatuses = dict["ProductStatuses"];
        vm.ProductMaterials = dict["ProductMaterials"];
        vm.ProductSourceTypes = dict["ProductSourceTypes"];
        vm.ProductDestinationTypes = dict["ProductDestinationTypes"];
        vm.ProductTypes = dict["ProductTypes"];
        vm.ProductGroups = dict["ProductGroups"];
        vm.ProductBrands = dict["ProductBrands"];
        vm.ProductCollections = dict["ProductCollections"];
    }
}
