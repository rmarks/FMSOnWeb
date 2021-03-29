using System;
using System.ComponentModel.DataAnnotations;

namespace FMS.Domain.Models
{
    public class Location
    {
        public int Id { get; set; }
        
        [Required, MaxLength(50)]
        public string Name { get; set; }
        
        public int LocationTypeId { get; set; }
        public LocationType LocationType { get; set; }
    }
}
