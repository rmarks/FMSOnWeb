using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FMS.Domain.Models
{
    public class ProductBase
    {
        public int Id { get; set; }
        
        [Required, MaxLength(12)]
        public string Code { get; set; }
        
        [Required, MaxLength(50)]
        public string Name { get; set; }

        public string Comments { get; set; }

        public int? ProductStatusId { get; set; }
        public ProductStatus ProductStatus { get; set; }

        public int? ProductSourceTypeId { get; set; }
        public ProductSourceType ProductSourceType { get; set; }

        public int? ProductDestinationTypeId { get; set; }
        public ProductDestinationType ProductDestinationType { get; set; }

        public int? ProductMaterialId { get; set; }
        public ProductMaterial ProductMaterial { get; set; }

        public int? ProductTypeId { get; set; }
        public ProductType ProductType { get; set; }

        public int? ProductGroupId { get; set; }
        public ProductGroup ProductGroup { get; set; }

        public int? ProductBrandId { get; set; }
        public ProductBrand ProductBrand { get; set; }

        public int? ProductCollectionId { get; set; }
        public ProductCollection ProductCollection { get; set; }

        public int? ProductVariantTypeId { get; set; }
        public ProductVariantType ProductVariantType { get; set; }

        public IList<Product> Products { get; set; }
    }
}
