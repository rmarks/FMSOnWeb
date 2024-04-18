using FMS.Web.Shared.Features.Shared.Dropdowns;

namespace FMS.Web.Shared.Features.Product
{
    public class ProductBasicsDropdowns
    {
        public IEnumerable<DropdownDto> ProductStatuses { get; set; }
        public IEnumerable<DropdownDto> ProductMaterials { get; set; }
        public IEnumerable<DropdownDto> ProductSourceTypes { get; set; }
        public IEnumerable<DropdownDto> ProductDestinationTypes { get; set; }
        public IEnumerable<DropdownDto> ProductTypes { get; set; }
        public IEnumerable<ChildDropdownDto> ProductGroups { get; set; }
        public IEnumerable<DropdownDto> ProductBrands { get; set; }
        public IEnumerable<ChildDropdownDto> ProductCollections { get; set; }
    }
}
