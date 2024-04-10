using System.ComponentModel.DataAnnotations;

namespace FMS.Domain.Models
{
    public class ProductBase
    {
        public int Id { get; set; }
        
        [Required, MaxLength(12)]
        public string Code { get; set; } = string.Empty;
        
        [Required, MaxLength(50)]
        public string Name { get; set; } = string.Empty;

        public string Comments { get; set; } = string.Empty;

        public int? ProductStatusId { get; set; }
        public ProductStatus ProductStatus { get; set; } = default!;

        public int? ProductSourceTypeId { get; set; }
        public ProductSourceType ProductSourceType { get; set; } = default!;

        public int? ProductDestinationTypeId { get; set; }
        public ProductDestinationType ProductDestinationType { get; set; } = default!;

        public int? ProductMaterialId { get; set; }
        public ProductMaterial ProductMaterial { get; set; } = default!;

        public int? ProductTypeId { get; set; }
        public ProductType ProductType { get; set; } = default!;

        public int? ProductGroupId { get; set; }
        public ProductGroup ProductGroup { get; set; } = default!;

        public int? ProductBrandId { get; set; }
        public ProductBrand ProductBrand { get; set; } = default!;

        public int? ProductCollectionId { get; set; }
        public ProductCollection ProductCollection { get; set; } = default!;

        public int? ProductVariantTypeId { get; set; }
        public ProductVariantType ProductVariantType { get; set; } = default!;

        public ICollection<Product> Products { get; set; } = default!;
    }
}
