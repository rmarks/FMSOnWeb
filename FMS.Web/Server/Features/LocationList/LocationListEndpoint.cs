using Ardalis.ApiEndpoints;
using FMS.DAL;
using FMS.Web.Server.Extensions;
using FMS.Web.Shared.Features.LocationList;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FMS.Web.Server.Features.LocationList
{
    public class LocationListEndpoint : BaseAsyncEndpoint.WithRequest<LocationListRequest>.WithResponse<LocationListRequest.Response>
    {
        private readonly FMSContext _context;

        public LocationListEndpoint(FMSContext context)
        {
            _context = context;
        }

        [HttpPost("api/locations")]
        public override async Task<ActionResult<LocationListRequest.Response>> HandleAsync(LocationListRequest request, CancellationToken cancellationToken = default)
        {
            var query = _context.Locations
                .AsNoTracking();

            if (request.Options.LocationTypeId > 0)
            {
                query = query.Where(l => l.LocationTypeId == request.Options.LocationTypeId);
            }

            var pagedLocations = await query
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
                .GetPagedAsync(request.Options.CurrentPage, request.Options.PageSize);

            return new LocationListRequest.Response(pagedLocations);
        }
    }
}
