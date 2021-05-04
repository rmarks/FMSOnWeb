using FMS.DAL;
using FMS.Web.Server.Extensions;
using FMS.Web.Shared;
using FMS.Web.Shared.Dropdowns;
using FMS.Web.Shared.Dtos;
using FMS.Web.Shared.Options;
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
            return new LocationInventoryDto
            {
                LocationName = (await _context.Locations
                    .AsNoTracking()
                    .FirstOrDefaultAsync(l => l.Id == locationId))
                    .Name,

                PagedInventory = await GetInventoryList(locationId, options)
            };
        }

        // POST: api/locationinventory/locationid/list
        [HttpPost("{locationId}/list")]
        public async Task<ActionResult<PagedResult<LocationInventoryListDto>>> GetLocationInventoryList(int locationId, LocationInventoryListOptions options)
        {
            return await GetInventoryList(locationId, options);
        }

        // GET: api/locationinventory/locationid/product/productid
        [HttpGet("{locationId}/product/{productId}")]
        public async Task<InventoryDetailsDto> GetProductDetails(int locationId, int productId)
        {
            return new InventoryDetailsDto
            {
                ProductInventory = await _context.Inventory
                    .AsNoTracking()
                    .Where(i => i.LocationId == locationId && i.ProductId == productId)
                    .Select(i => new LocationInventoryListDto
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
                    .Select(p => new InventoryPriceListDto
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

        #region helpers
        private async Task<PagedResult<LocationInventoryListDto>> GetInventoryList(int locationId, LocationInventoryListOptions options)
        {
            var query = _context.Inventory
                .AsNoTracking()
                .Where(i => i.LocationId == locationId);

            if (options.ProductStatusId > 0)
            {
                query = query.Where(i => i.Product.ProductStatusId == options.ProductStatusId);
            };

            if (options.ProductMaterialId > 0)
            {
                query = query.Where(i => i.Product.ProductMaterialId == options.ProductMaterialId);
            };

            if (options.ProductSourceTypeId > 0)
            {
                query = query.Where(i => i.Product.ProductSourceTypeId == options.ProductSourceTypeId);
            };

            if (options.ProductDestinationTypeId > 0)
            {
                query = query.Where(i => i.Product.ProductDestinationTypeId == options.ProductDestinationTypeId);
            };

            if (options.ProductGroupId > 0)
            {
                query = query.Where(i => i.Product.ProductGroupId == options.ProductGroupId);
            }
            else if (options.ProductTypeId > 0)
            {
                query = query.Where(i => i.Product.ProductTypeId == options.ProductTypeId);
            };

            if (options.ProductCollectionId > 0)
            {
                query = query.Where(i => i.Product.ProductCollectionId == options.ProductCollectionId);
            }
            else if (options.ProductBrandId > 0)
            {
                query = query.Where(i => i.Product.ProductBrandId == options.ProductBrandId);
            };

            return await query
                .Select(i => new LocationInventoryListDto
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
                .GetPagedAsync(options.CurrentPage, options.PageSize);
        }
        #endregion
    }
}
