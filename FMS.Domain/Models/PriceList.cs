using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FMS.Domain.Models
{
    public class PriceList
    {
        public int Id { get; set; }
        
        [Required, MaxLength(30)]
        public string Name { get; set; }
        
        [Required, MaxLength(3)]
        public string CurrencyCode { get; set; }

        public IList<Price> Prices { get; set; }
    }
}
