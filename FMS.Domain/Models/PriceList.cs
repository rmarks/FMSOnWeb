using System.ComponentModel.DataAnnotations;

namespace FMS.Domain.Models
{
    public class PriceList
    {
        public int Id { get; set; }
        
        [Required, MaxLength(30)]
        public string Name { get; set; } = string.Empty;
        
        [Required, MaxLength(3)]
        public string CurrencyCode { get; set; } = string.Empty;

        public ICollection<Price> Prices { get; set; } = default!;
    }
}
