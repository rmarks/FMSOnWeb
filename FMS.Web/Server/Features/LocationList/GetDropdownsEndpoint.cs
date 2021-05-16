using Ardalis.ApiEndpoints;
using FMS.DAL;
using FMS.Web.Shared.Features.Shared;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace FMS.Web.Server.Features.LocationList
{
    public class GetDropdownsEndpoint : BaseAsyncEndpoint.WithoutRequest.WithResponse<IEnumerable<DropdownDto>>
    {
        private readonly FMSContext _context;

        public GetDropdownsEndpoint(FMSContext context)
        {
            _context = context;
        }

        [HttpGet("api/locations/dropdowns")]
        public override async Task<ActionResult<IEnumerable<DropdownDto>>> HandleAsync(CancellationToken cancellationToken = default)
        {
            return await _context.LocationTypes
                .AsNoTracking()
                .Select(l => new DropdownDto
                {
                    Id = l.Id,
                    Name = l.Name
                })
                .ToListAsync();
        }
    }
}
