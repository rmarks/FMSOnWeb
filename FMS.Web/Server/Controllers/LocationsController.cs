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

        // GET: api/Locations
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LocationListItemDto>>> GetLocations()
        {
            return await _context.Locations
                .AsNoTracking()
                .Select(l => new LocationListItemDto
                {
                    LocationId = l.Id,
                    LocationTypeName = l.LocationType.Name,
                    LocationName = l.Name
                })
                .ToListAsync();
        }
    }
}
