using System.Collections.Generic;

namespace FMS.Web.Shared.Features.Product
{
    public class ProductPricesDto
    {
        public int ProductBaseId { get; set; }
        public int PriceListId { get; set; }
        public IList<ProductPriceDto> Prices { get; set; }

        public class ProductPriceDto
        {
            public int Id { get; set; }
            public int ProductId { get; set; }
            public string ProductCode { get; set; }
            public decimal UnitPrice { get; set; }
            public int PriceListId { get; set; }
        }
    }
}
