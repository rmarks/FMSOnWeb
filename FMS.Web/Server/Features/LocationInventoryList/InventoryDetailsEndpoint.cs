using Ardalis.ApiEndpoints;
using FMS.DAL;
using FMS.Web.Shared.Features.LocationInventoryList;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace FMS.Web.Server.Features.LocationInventoryList
{
    public class InventoryDetailsEndpoint : BaseAsyncEndpoint.WithRequest<InventoryDetailsRequest>.WithResponse<InventoryDetailsRequest.Response>
    {
        private readonly FMSContext _context;

        public InventoryDetailsEndpoint(FMSContext context)
        {
            _context = context;
        }

        [HttpPost("api/locationinventory/details")]
        public override async Task<ActionResult<InventoryDetailsRequest.Response>> HandleAsync(InventoryDetailsRequest request, CancellationToken cancellationToken = default)
        {
            var inventoryDetailsDto = new InventoryDetailsDto
            {
                ProductBaseInventory = await _context.Inventory
                    .AsNoTracking()
                    .Where(i => i.LocationId == request.LocationId && i.Product.ProductBaseId == request.ProductBaseId)
                    .GroupBy(i => new { i.Product.ProductBase.Id, i.Product.ProductBase.Code, i.Product.ProductBase.Name, i.LocationId },
                         i => i,
                         (key, g) => new LocationInventoryListDto
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
                    .Where(p => p.Product.ProductBaseId == request.ProductBaseId && p.PriceList.Name.ToLower().Contains("eesti"))
                    .OrderBy(p => p.Product.Code)
                    .Select(p => new ProductPriceDto
                    {
                        ProductId = p.ProductId,
                        ProductCode = p.Product.Code,
                        UnitPrice = p.UnitPrice,
                        CurrencyCode = p.PriceList.CurrencyCode,
                        PriceListId = p.PriceListId
                    })
                    .ToListAsync()
            };

            return new InventoryDetailsRequest.Response(inventoryDetailsDto);
        }
    }
}
