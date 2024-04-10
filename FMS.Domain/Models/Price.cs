using System.ComponentModel.DataAnnotations.Schema;

namespace FMS.Domain.Models
{
    public class Price
    {
        public int Id { get; set; }

        public int ProductId { get; set; }
        public Product Product { get; set; } = default!;

        public int PriceListId { get; set; }
        public PriceList PriceList { get; set; } = default!;

        [Column(TypeName = "decimal(9, 2)")]
        public decimal UnitPrice { get; set; }
    }
}
