using FastEndpoints;
using FMS.DAL;
using FMS.Web.Shared.Features.LocationInventoryList;
using Microsoft.EntityFrameworkCore;

namespace FMS.Web.Server.Features.LocationInventoryList;

public class GetInventoryDetailsEndpoint : Endpoint<GetInventoryDetailsRequest, GetInventoryDetailsRequest.Response>
{
    private readonly FMSContext _context;

    public GetInventoryDetailsEndpoint(FMSContext context)
    {
        _context = context;
    }

    public override void Configure()
    {
        Post(GetInventoryDetailsRequest.RouteTemplate);
        AllowAnonymous();
    }

    public override async Task HandleAsync(GetInventoryDetailsRequest req, CancellationToken ct)
    {
        var inventoryDetails = new InventoryDetailsVm
        {
            ProductBaseInventory = await _context.Inventory
                .AsNoTracking()
                .Where(i => i.LocationId == req.LocationId && i.Product.ProductBaseId == req.ProductBaseId)
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
                .FirstOrDefaultAsync(),

            ProductPrices = await _context.Prices
                .AsNoTracking()
                .Where(p => p.Product.ProductBaseId == req.ProductBaseId && p.PriceList.Name.ToLower().Contains("eesti"))
                .OrderBy(p => p.Product.Code)
                .Select(p => new ProductPriceVm
                {
                    ProductId = p.ProductId,
                    ProductCode = p.Product.Code,
                    UnitPrice = p.UnitPrice,
                    CurrencyCode = p.PriceList.CurrencyCode,
                    PriceListId = p.PriceListId
                })
                .ToListAsync()
        };

        Response = new GetInventoryDetailsRequest.Response(inventoryDetails);
    }
}
