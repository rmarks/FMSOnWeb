namespace FMS.Web.Shared.Features.Product
{
    public class ProductPriceItemDto
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public string ProductCode { get; set; }
        public decimal UnitPrice { get; set; }
        public int PriceListId { get; set; }
    }
}
