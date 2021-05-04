using System.Collections.Generic;

namespace FMS.Web.Shared.Dtos
{
    public class InventoryDetailsDto
    {
        public LocationInventoryListDto ProductInventory { get; set; }

        public IList<InventoryPriceListDto> ProductPrices { get; set; }
    }
}
