﻿using System.ComponentModel.DataAnnotations;

namespace FMS.Domain.Models
{
    public class ProductDestinationType
    {
        public int Id { get; set; }
        
        [Required, MaxLength(30)]
        public string Name { get; set; } = string.Empty;
    }
}
