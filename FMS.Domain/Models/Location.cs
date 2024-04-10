using System.ComponentModel.DataAnnotations;

namespace FMS.Domain.Models
{
    public class Location
    {
        public int Id { get; set; }

        [Required, MaxLength(10)]
        public string Code { get; set; } = string.Empty;

        [Required, MaxLength(50)]
        public string Name { get; set; } = string.Empty;
        
        public int LocationTypeId { get; set; }
        public LocationType LocationType { get; set; } = default!;

        public ICollection<Inventory> Inventory { get; set; } = default!;
    }
}
