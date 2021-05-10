using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FMS.Domain.Models
{
    public class Product
    {
        public int Id { get; set; }
        
        [Required, MaxLength(15)]
        public string Code { get; set; }
        
        [Required, MaxLength(50)]
        public string Name { get; set; }

        public int ProductBaseId { get; set; }
        public ProductBase ProductBase { get; set; }

        public int? ProductVariantId { get; set; }
        public ProductVariant ProductVariant { get; set; }

        public IList<Inventory> Inventory { get; set; }
    }
}
