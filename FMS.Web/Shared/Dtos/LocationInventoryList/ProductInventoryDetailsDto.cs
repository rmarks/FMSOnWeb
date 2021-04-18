using System.Collections.Generic;

namespace FMS.Web.Shared.Dtos
{
    public class ProductInventoryDetailsDto
    {
        public ProductInventoryInLocationDto ProductInventory { get; set; }

        public IList<ProductPriceInPriceListDto> ProductPrices { get; set; }
    }
}
