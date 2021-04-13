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
        public async Task<ActionResult<PagedResult<LocationInventoryListItemDto>>> GetLocationInventory(int locationId, int page, int pageSize)
        {
            return await _context.Inventory
                .AsNoTracking()
                .Where(i => i.LocationId == locationId)
                .Select(i => new LocationInventoryListItemDto
                {
                    InvnetoryId = i.Id,
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
    }
}
