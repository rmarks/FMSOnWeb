namespace FMS.Domain.Models
{
    public class Inventory
    {
        public int Id { get; set; }

        public int LocationId { get; set; }
        public Location Location { get; set; } = default!;

        public int ProductId { get; set; }
        public Product Product { get; set; } = default!;

        public int StockQuantity { get; set; }
        public int ReservedQuantity { get; set; }
    }
}
