using FastEndpoints;
using FMS.DAL;
using FMS.Web.Server.Extensions;
using FMS.Web.Shared.Features.LocationList;
using Microsoft.EntityFrameworkCore;

namespace FMS.Web.Server.Features.LocationList;

public class GetLocationListEndpoint : Endpoint<GetLocationListRequest, GetLocationListRequest.Response>
{
    private readonly FMSContext _context;

    public GetLocationListEndpoint(FMSContext context)
    {
        _context = context;
    }

    public override void Configure()
    {
        Post("/api/locations");
        AllowAnonymous();
    }

    public override async Task HandleAsync(GetLocationListRequest req, CancellationToken ct)
    {
        var query = _context.Locations
            .AsNoTracking();

        if (req.Filter.LocationTypeId > 0)
        {
            query = query.Where(l => l.LocationTypeId == req.Filter.LocationTypeId);
        }

        var pagedLocations = await query
            .Select(l => new LocationListVm
            {
                LocationId = l.Id,
                LocationTypeId = l.LocationTypeId,
                LocationCode = l.Code,
                LocationName = l.Name,
                TotalCount = l.Inventory.GroupBy(i => i.Product.ProductBase.Code).Count(),
                TotalStockQuantity = l.Inventory.Sum(i => i.StockQuantity),
                TotalReservedQuantity = l.Inventory.Sum(i => i.ReservedQuantity)
            })
            .GetPagedAsync(req.Filter.CurrentPage, req.Filter.PageSize);

        Response = new GetLocationListRequest.Response(pagedLocations);
    }
}
