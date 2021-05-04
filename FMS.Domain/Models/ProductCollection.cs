using System.ComponentModel.DataAnnotations;

namespace FMS.Domain.Models
{
    public class ProductCollection
    {
        public int Id { get; set; }
        
        [Required, MaxLength(30)]
        public string Name { get; set; }

        public int ProductBrandId { get; set; }
        public ProductBrand ProductBrand { get; set; }
    }
}
