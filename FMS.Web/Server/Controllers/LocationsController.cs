using FMS.DAL;
using FMS.Web.Shared.Dtos;
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
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LocationListItemDto>>> GetLocations()
        {
            return await _context.Locations
                .AsNoTracking()
                .Select(l => new LocationListItemDto
                {
                    LocationId = l.Id,
                    LocationTypeId = l.LocationTypeId,
                    LocationCode = l.Code,
                    LocationName = l.Name,
                    TotalCount = l.Inventory.Count()
                })
                .ToListAsync();
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
