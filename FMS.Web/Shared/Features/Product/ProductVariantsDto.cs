using System.Collections.Generic;

namespace FMS.Web.Shared.Features.Product
{
    public class ProductVariantsDto
    {
        public int Id { get; set; }
        public int? ProductVariantTypeId { get; set; }
        public IList<ProductDto> Products { get; set; }

        public class ProductDto
        {
            public int Id { get; set; }
            public string Code { get; set; }
            public string Name { get; set; }
            public int ProductBaseId { get; set; }
        }
    }
}
