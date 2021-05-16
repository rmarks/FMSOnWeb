using System.Collections.Generic;

namespace FMS.Web.Shared.Features.LocationInventoryList
{
    public class InventoryDetailsDto
    {
        public LocationInventoryListDto ProductBaseInventory { get; set; }

        public IList<InventoryPriceListDto> ProductPrices { get; set; }
    }
}
