using System.Collections.Generic;

namespace FMS.Web.Shared.Dtos
{
    public class ProductBaseProductsDto
    {
        public int Id { get; set; }
        public int? ProductVariantTypeId { get; set; }
        public IList<ProductDto> Products { get; set; }
    }
}
