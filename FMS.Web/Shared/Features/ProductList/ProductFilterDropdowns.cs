using FMS.Web.Shared.Features.Shared;
using System.Collections.Generic;
using System.Linq;

namespace FMS.Web.Shared.Features.ProductList
{
    public class ProductFilterDropdowns
    {
        public IEnumerable<DropdownDto> ProductStatuses { get; set; }
        public IEnumerable<DropdownDto> ProductMaterials { get; set; }
        public IEnumerable<DropdownDto> ProductSourceTypes { get; set; }
        public IEnumerable<DropdownDto> ProductDestinationTypes { get; set; }
        public IEnumerable<DropdownDto> ProductTypes { get; set; }
        public IEnumerable<ChildDropdownDto> ProductGroups { get; set; }
        public IEnumerable<DropdownDto> ProductBrands { get; set; }
        public IEnumerable<ChildDropdownDto> ProductCollections { get; set; }

        public IEnumerable<ChildDropdownDto> GetFilteredProductGroups(int? productTypeId)
        {
            if (productTypeId > 0)
            {
                return ProductGroups.Where(p => p.ParentId == productTypeId).ToList();
            }

            return Enumerable.Empty<ChildDropdownDto>();
        }

        public IEnumerable<ChildDropdownDto> GetFilteredProductCollections(int? productBrandId)
        {
            if (productBrandId > 0)
            {
                return ProductCollections.Where(p => p.ParentId == productBrandId).ToList();
            }

            return Enumerable.Empty<ChildDropdownDto>();
        }
    }
}
