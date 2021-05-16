using FMS.DAL;
using FMS.ServiceLayer.LocationServices;
using FMS.Web.Shared;
using FMS.Web.Shared.Features.LocationInventoryList;
using FMS.Web.Shared.Features.Shared;
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

        // POST: api/locationinventory/locationid
        [HttpPost("{locationId}")]
        public async Task<ActionResult<LocationInventoryDto>> GetLocationInventory(int locationId, LocationInventoryListOptions options)
        {
            var service = new InventoryService(_context);

            return new LocationInventoryDto
            {
                LocationName = (await _context.Locations
                    .AsNoTracking()
                    .FirstOrDefaultAsync(l => l.Id == locationId))
                    .Name,

                PagedInventory = await service.GetLocationInventory(locationId, options)
            };
        }

        // POST: api/locationinventory/locationid/list
        [HttpPost("{locationId}/list")]
        public async Task<ActionResult<PagedResult<LocationInventoryListDto>>> GetLocationInventoryList(int locationId, LocationInventoryListOptions options)
        {
            var service = new InventoryService(_context);

            return await service.GetLocationInventory(locationId, options);
        }

        // GET: api/locationinventory/locationid/product/productid
        [HttpGet("{locationId}/product/{productBaseId}")]
        public async Task<InventoryDetailsDto> GetProductDetails(int locationId, int productBaseId)
        {
            return new InventoryDetailsDto
            {
                ProductBaseInventory = await _context.Inventory
                    .AsNoTracking()
                    .Where(i => i.LocationId == locationId && i.Product.ProductBaseId == productBaseId)
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
                    .Where(p => p.Product.ProductBaseId == productBaseId && p.PriceList.Name.ToLower().Contains("eesti"))
                    .OrderBy(p => p.Product.Code)
                    .Select(p => new InventoryPriceListDto
                    {
                        ProductId = p.ProductId,
                        ProductCode = p.Product.Code,
                        UnitPrice = p.UnitPrice,
                        CurrencyCode = p.PriceList.CurrencyCode,
                        PriceListId = p.PriceListId
                    })
                    .ToListAsync()
            };
        }

        // GET: api/locationinventory/dropdowns
        [HttpGet("dropdowns")]
        public async Task<LocationInventoryDropdowns> GetDropdowns()
        {
            return new LocationInventoryDropdowns
            {
                ProductStatuses = await _context.ProductStatuses
                    .AsNoTracking()
                    .Select(p => new DropdownDto
                    {
                        Id = p.Id,
                        Name = p.Name
                    })
                    .ToListAsync(),

                ProductMaterials = await _context.ProductMaterials
                    .AsNoTracking()
                    .Select(p => new DropdownDto
                    {
                        Id = p.Id,
                        Name = p.Name
                    })
                    .ToListAsync(),

                ProductSourceTypes = await _context.ProductSourceTypes
                    .AsNoTracking()
                    .Select(p => new DropdownDto
                    {
                        Id = p.Id,
                        Name = p.Name
                    })
                    .ToListAsync(),

                ProductDestinationTypes = await _context.ProductDestinationTypes
                    .AsNoTracking()
                    .Select(p => new DropdownDto
                    {
                        Id = p.Id,
                        Name = p.Name
                    })
                    .ToListAsync(),

                ProductTypes = await _context.ProductTypes
                    .AsNoTracking()
                    .Select(p => new DropdownDto
                    {
                        Id = p.Id,
                        Name = p.Name
                    })
                    .ToListAsync(),

                ProductGroups = await _context.ProductGroups
                    .AsNoTracking()
                    .Select(p => new ChildDropdownDto
                    {
                        Id = p.Id,
                        Name = p.Name,
                        ParentId = p.ProductTypeId
                    })
                    .ToListAsync(),

                ProductBrands = await _context.ProductBrands
                    .AsNoTracking()
                    .Select(p => new DropdownDto
                    {
                        Id = p.Id,
                        Name = p.Name
                    })
                    .ToListAsync(),

                ProductCollections = await _context.ProductCollections
                    .AsNoTracking()
                    .Select(p => new ChildDropdownDto
                    {
                        Id = p.Id,
                        Name = p.Name,
                        ParentId = p.ProductBrandId
                    })
                    .ToListAsync()
            };
        }
    }
}
