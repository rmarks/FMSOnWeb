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

        public IList<Inventory> Inventory { get; set; }
    }
}
