using FMS.DAL;
using FMS.Web.Server.Extensions;
using FMS.Web.Shared;
using FMS.Web.Shared.Dtos;
using FMS.Web.Shared.Options;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FMS.Web.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationsController : ControllerBase
    {
        private readonly FMSContext _context;

        public LocationsController(FMSContext context)
        {
            _context = context;
        }

        // GET: api/locations
        //[HttpGet]
        // POST: api/locations
        [HttpPost]
        public async Task<ActionResult<PagedResult<LocationListItemDto>>> GetLocations(LocationListOptions options)
        {
            var query = _context.Locations
                .AsNoTracking();

            if (options.LocationTypeId > 0)
            {
                query = query.Where(l => l.LocationTypeId == options.LocationTypeId);
            }

            return await query
                .Select(l => new LocationListItemDto
                {
                    LocationId = l.Id,
                    LocationTypeId = l.LocationTypeId,
                    LocationCode = l.Code,
                    LocationName = l.Name,
                    TotalCount = l.Inventory.Count(),
                    TotalStockQuantity = l.Inventory.Sum(i => i.StockQuantity),
                    TotalReservedQuantity = l.Inventory.Sum(i => i.ReservedQuantity)
                })
                .GetPagedAsync(options.CurrentPage, options.PageSize);
        }

        // GET: api/locations/dropdowns
        [HttpGet("dropdowns")]
        public async Task<ActionResult<IEnumerable<LocationTypeDropdownItemDto>>> GetDropdowns()
        {
            return await _context.LocationTypes
                .AsNoTracking()
                .Select(l => new LocationTypeDropdownItemDto
                {
                    Id = l.Id,
                    Name = l.Name
                })
                .ToListAsync();
        }
    }
}
