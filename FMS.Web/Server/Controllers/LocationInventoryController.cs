using FMS.DAL;
using FMS.Web.Server.Extensions;
using FMS.Web.Shared;
using FMS.Web.Shared.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace FMS.Web.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationInventoryController : ControllerBase
    {
        private readonly FMSContext _context;

        public LocationInventoryController(FMSContext context)
        {
            _context = context;
        }

        // GET: api/locationinventory/locationid
        [HttpGet("{locationId}")]
        public async Task<ActionResult<PagedResult<ProductInventoryInLocationDto>>> GetLocationInventory(int locationId, int page, int pageSize)
        {
            return await _context.Inventory
                .AsNoTracking()
                .Where(i => i.LocationId == locationId)
                .Select(i => new ProductInventoryInLocationDto
                {
                    InventoryId = i.Id,
                    LocationId = i.LocationId,
                    ProductId = i.ProductId,
                    ProductCode = i.Product.Code,
                    ProductName = i.Product.Name,
                    StockQuantity = i.StockQuantity,
                    ReservedQuantity = i.ReservedQuantity
                })
                .OrderBy(l => l.ProductCode)
                .GetPagedAsync(page, pageSize);
        }

        // GET: api/locationinventory/locationid/product/productid
        [HttpGet("{locationId}/product/{productId}")]
        public async Task<ProductInventoryDetailsDto> GetProductDetails(int locationId, int productId)
        {
            return new ProductInventoryDetailsDto
            {
                ProductInventory = await _context.Inventory
                    .AsNoTracking()
                    .Where(i => i.LocationId == locationId && i.ProductId == productId)
                    .Select(i => new ProductInventoryInLocationDto
                    {
                        InventoryId = i.Id,
                        LocationId = i.LocationId,
                        ProductId = i.ProductId,
                        ProductCode = i.Product.Code,
                        ProductName = i.Product.Name,
                        StockQuantity = i.StockQuantity,
                        ReservedQuantity = i.ReservedQuantity
                    })
                    .FirstOrDefaultAsync(),

                ProductPrices = await _context.Prices
                    .AsNoTracking()
                    .Where(p => p.ProductId == productId)
                    .OrderBy(p => p.PriceList.Name)
                    .Select(p => new ProductPriceInPriceListDto
                    {
                        ProductId = p.ProductId,
                        PriceListId = p.PriceListId,
                        PriceListName = p.PriceList.Name,
                        UnitPrice = p.UnitPrice,
                        CurrencyCode = p.PriceList.CurrencyCode
                    })
                    .ToListAsync()
            };
        }
    }
}
