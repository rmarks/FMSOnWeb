using FastEndpoints;
using FMS.DAL;
using FMS.Web.Server.Extensions;
using FMS.Web.Shared.Features.LocationInventoryList;
using Microsoft.EntityFrameworkCore;

namespace FMS.Web.Server.Features.LocationInventoryList;

public class GetLocationInventoryListEndpoint : Endpoint<GetLocationInventoryListRequest, GetLocationInventoryListRequest.Response>
{
    private readonly FMSContext _context;

    public GetLocationInventoryListEndpoint(FMSContext context)
    {
        _context = context;
    }

    public override void Configure()
    {
        Post("api/locationinventory");
        AllowAnonymous();
    }

    public override async Task HandleAsync(GetLocationInventoryListRequest req, CancellationToken ct)
    {
        string? locationName = null;

        if (req.IsLocationNameRequired)
        {
            locationName = (await _context.Locations
                .AsNoTracking()
                .FirstOrDefaultAsync(l => l.Id == req.LocationId))?
                .Name ?? "";
        }

        var query = _context.Inventory
            .AsNoTracking()
            .Where(i => i.LocationId == req.LocationId);

        var filter = req.Filter;

        if (filter.ProductStatusId > 0)
        {
            query = query.Where(i => i.Product.ProductBase.ProductStatusId == filter.ProductStatusId);
        };

        if (filter.ProductMaterialId > 0)
        {
            query = query.Where(i => i.Product.ProductBase.ProductMaterialId == filter.ProductMaterialId);
        };

        if (filter.ProductSourceTypeId > 0)
        {
            query = query.Where(i => i.Product.ProductBase.ProductSourceTypeId == filter.ProductSourceTypeId);
        };

        if (filter.ProductDestinationTypeId > 0)
        {
            query = query.Where(i => i.Product.ProductBase.ProductDestinationTypeId == filter.ProductDestinationTypeId);
        };

        if (filter.ProductGroupId > 0)
        {
            query = query.Where(i => i.Product.ProductBase.ProductGroupId == filter.ProductGroupId);
        }
        else if (filter.ProductTypeId > 0)
        {
            query = query.Where(i => i.Product.ProductBase.ProductTypeId == filter.ProductTypeId);
        };

        if (filter.ProductCollectionId > 0)
        {
            query = query.Where(i => i.Product.ProductBase.ProductCollectionId == filter.ProductCollectionId);
        }
        else if (filter.ProductBrandId > 0)
        {
            query = query.Where(i => i.Product.ProductBase.ProductBrandId == filter.ProductBrandId);
        };

        var pagedInventory = await query
            .GroupBy(i => new { i.Product.ProductBase.Id, i.Product.ProductBase.Code, i.Product.ProductBase.Name, i.LocationId },
                     i => i,
                     (key, g) => new LocationInventoryListVm
                     {
                         ProductBaseId = key.Id,
                         ProductBaseCode = key.Code,
                         ProductBaseName = key.Name,
                         LocationId = key.LocationId,
                         StockQuantity = g.Sum(i => i.StockQuantity),
                         ReservedQuantity = g.Sum(i => i.ReservedQuantity)
                     })
            .OrderBy(l => l.ProductBaseCode)
            .GetPagedAsync(filter.CurrentPage, filter.PageSize);

        Response = new GetLocationInventoryListRequest.Response(locationName, pagedInventory);
    }
}
