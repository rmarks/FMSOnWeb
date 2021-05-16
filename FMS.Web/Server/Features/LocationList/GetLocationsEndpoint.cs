using Ardalis.ApiEndpoints;
using FMS.DAL;
using FMS.Web.Server.Extensions;
using FMS.Web.Shared.Features.LocationList;
using FMS.Web.Shared.Features.Shared;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace FMS.Web.Server.Features.LocationList
{
    public class GetLocationsEndpoint : BaseAsyncEndpoint.WithRequest<LocationListOptions>.WithResponse<PagedResult<LocationListDto>>
    {
        private readonly FMSContext _context;

        public GetLocationsEndpoint(FMSContext context)
        {
            _context = context;
        }

        [HttpPost("api/locations")]
        public override async Task<ActionResult<PagedResult<LocationListDto>>> HandleAsync(LocationListOptions options, CancellationToken cancellationToken = default)
        {
            var query = _context.Locations
                .AsNoTracking();

            if (options.LocationTypeId > 0)
            {
                query = query.Where(l => l.LocationTypeId == options.LocationTypeId);
            }

            return await query
                .Select(l => new LocationListDto
                {
                    LocationId = l.Id,
                    LocationTypeId = l.LocationTypeId,
                    LocationCode = l.Code,
                    LocationName = l.Name,
                    TotalCount = l.Inventory.GroupBy(i => i.Product.ProductBase.Code).Count(),
                    TotalStockQuantity = l.Inventory.Sum(i => i.StockQuantity),
                    TotalReservedQuantity = l.Inventory.Sum(i => i.ReservedQuantity)
                })
                .GetPagedAsync(options.CurrentPage, options.PageSize);
        }
    }
}
