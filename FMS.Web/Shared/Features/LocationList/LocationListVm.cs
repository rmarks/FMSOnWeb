namespace FMS.Web.Shared.Features.LocationList;

public class LocationListVm
{
    public int LocationId { get; set; }

    public int LocationTypeId { get; set; }

    public string LocationCode { get; set; } = string.Empty;
    public string LocationName { get; set; } = string.Empty;
    
    public int TotalCount { get; set; }

    public int TotalStockQuantity { get; set; }
    public int TotalReservedQuantity { get; set; }
    public int TotalFreeQuantity => TotalStockQuantity - TotalReservedQuantity;
}
