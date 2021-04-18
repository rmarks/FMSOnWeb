namespace FMS.Web.Shared.Dtos
{
    public class ProductInventoryInLocationDto
    {
        public int InventoryId { get; set; }

        public int ProductId { get; set; }
        public string ProductCode { get; set; }
        public string ProductName { get; set; }

        public int LocationId { get; set; }

        public int StockQuantity { get; set; }
        public int ReservedQuantity { get; set; }
        public int FreeQuantity => StockQuantity - ReservedQuantity;
    }
}
