namespace FMS.Web.Shared.Dtos
{
    public class InventoryPriceListDto
    {
        public int ProductId { get; set; }
        public string ProductCode { get; set; }

        public decimal UnitPrice { get; set; }
        public string CurrencyCode { get; set; }

        public int PriceListId { get; set; }
    }
}
