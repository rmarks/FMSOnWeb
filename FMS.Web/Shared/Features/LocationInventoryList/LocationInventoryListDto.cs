namespace FMS.Web.Shared.Features.LocationInventoryList
{
    public class LocationInventoryListDto
    {
        public int ProductBaseId { get; set; }
        public string ProductBaseCode { get; set; }
        public string ProductBaseName { get; set; }

        public int LocationId { get; set; }

        public int StockQuantity { get; set; }
        public int ReservedQuantity { get; set; }
        public int FreeQuantity => StockQuantity - ReservedQuantity;
    }
}
