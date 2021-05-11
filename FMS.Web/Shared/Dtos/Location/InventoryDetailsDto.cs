using System.Collections.Generic;

namespace FMS.Web.Shared.Dtos
{
    public class InventoryDetailsDto
    {
        public LocationInventoryListDto ProductBaseInventory { get; set; }

        public IList<InventoryPriceListDto> ProductPrices { get; set; }
    }
}
