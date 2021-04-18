namespace FMS.Web.Shared.Dtos
{
    public class ProductPriceInPriceListDto
    {
        public int ProductId { get; set; }

        public int PriceListId { get; set; }
        public string PriceListName { get; set; }

        public decimal UnitPrice { get; set; }
        public string CurrencyCode { get; set; }
    }
}
