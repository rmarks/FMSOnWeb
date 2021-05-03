using FMS.Web.Shared.Dtos;
using System.Collections.Generic;

namespace FMS.Web.Shared.Dropdowns
{
    public class LocationInventoryDropdowns
    {
        public IEnumerable<DropdownDto> ProductSourceTypes { get; set; }
        public IEnumerable<DropdownDto> ProductGroups { get; set; }
    }
}
