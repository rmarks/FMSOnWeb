namespace FMS.Web.Shared.Dtos
{
    public class LocationListDto
    {
        public int LocationId { get; set; }

        public int LocationTypeId { get; set; }

        public string LocationCode { get; set; }
        public string LocationName { get; set; }
        
        public int TotalCount { get; set; }
        
        public int TotalStockQuantity { get; set; }
        public int TotalReservedQuantity { get; set; }
        public int TotalFreeQuantity => TotalStockQuantity - TotalReservedQuantity;
    }
}
