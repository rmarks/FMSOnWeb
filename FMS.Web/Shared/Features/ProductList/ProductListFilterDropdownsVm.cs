using FMS.Web.Shared.Features.Shared;
using System.Collections.Generic;
using System.Linq;

namespace FMS.Web.Shared.Features.ProductList
{
    public class ProductListFilterDropdownsVm
    {
        public IEnumerable<DropdownVm> ProductStatuses { get; set; }
        public IEnumerable<DropdownVm> ProductMaterials { get; set; }
        public IEnumerable<DropdownVm> ProductSourceTypes { get; set; }
        public IEnumerable<DropdownVm> ProductDestinationTypes { get; set; }
        public IEnumerable<DropdownVm> ProductTypes { get; set; }
        public IEnumerable<ChildDropdownVm> ProductGroups { get; set; }
        public IEnumerable<DropdownVm> ProductBrands { get; set; }
        public IEnumerable<ChildDropdownVm> ProductCollections { get; set; }

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
}
