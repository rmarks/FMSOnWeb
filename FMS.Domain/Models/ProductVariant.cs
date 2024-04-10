using System.ComponentModel.DataAnnotations;

namespace FMS.Domain.Models
{
    public class ProductVariant
    {
        public int Id { get; set; }
        
        [Required, MaxLength(3)]
        public string Code { get; set; } = string.Empty;
        
        [Required, MaxLength(30)]
        public string Name { get; set; } = string.Empty;

        public int ProductVariantTypeId { get; set; }
        public ProductVariantType ProductVariantType { get; set; } = default!;
    }
}
