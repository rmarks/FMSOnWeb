using System.ComponentModel.DataAnnotations;

namespace FMS.Domain.Models
{
    public class Product
    {
        public int Id { get; set; }
        
        [Required, MaxLength(15)]
        public string Code { get; set; } = string.Empty;
        
        [Required, MaxLength(50)]
        public string Name { get; set; } = string.Empty;

        public int ProductBaseId { get; set; }
        public ProductBase ProductBase { get; set; } = default!;

        public int? ProductVariantId { get; set; }
        public ProductVariant ProductVariant { get; set; } = default!;

        public ICollection<Inventory> Inventory { get; set; } = default!;
    }
}
