using Ardalis.ApiEndpoints;
using FMS.DAL;
using FMS.Web.Server.Extensions;
using FMS.Web.Shared.Features.LocationInventoryList;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace FMS.Web.Server.Features.LocationInventoryList
{
    public class LocationInventoryListEndpoint : BaseAsyncEndpoint.WithRequest<LocationInventoryListRequest>.WithResponse<LocationInventoryListRequest.Response>
    {
        private readonly FMSContext _context;

        public LocationInventoryListEndpoint(FMSContext context)
        {
            _context = context;
        }

        [HttpPost("api/locationinventory")]
        public override async Task<ActionResult<LocationInventoryListRequest.Response>> HandleAsync(LocationInventoryListRequest request, CancellationToken cancellationToken = default)
        {
            string locationName = "";

            if (request.IsFirstRequest)
            {
                locationName = (await _context.Locations
                    .AsNoTracking()
                    .FirstOrDefaultAsync(l => l.Id == request.LocationId))
                    .Name;
            }

            var query = _context.Inventory
                .AsNoTracking()
                .Where(i => i.LocationId == request.LocationId);

            var options = request.Options;

            if (options.ProductStatusId > 0)
            {
                query = query.Where(i => i.Product.ProductBase.ProductStatusId == options.ProductStatusId);
            };

            if (options.ProductMaterialId > 0)
            {
                query = query.Where(i => i.Product.ProductBase.ProductMaterialId == options.ProductMaterialId);
            };

            if (options.ProductSourceTypeId > 0)
            {
                query = query.Where(i => i.Product.ProductBase.ProductSourceTypeId == options.ProductSourceTypeId);
            };

            if (options.ProductDestinationTypeId > 0)
            {
                query = query.Where(i => i.Product.ProductBase.ProductDestinationTypeId == options.ProductDestinationTypeId);
            };

            if (options.ProductGroupId > 0)
            {
                query = query.Where(i => i.Product.ProductBase.ProductGroupId == options.ProductGroupId);
            }
            else if (options.ProductTypeId > 0)
            {
                query = query.Where(i => i.Product.ProductBase.ProductTypeId == options.ProductTypeId);
            };

            if (options.ProductCollectionId > 0)
            {
                query = query.Where(i => i.Product.ProductBase.ProductCollectionId == options.ProductCollectionId);
            }
            else if (options.ProductBrandId > 0)
            {
                query = query.Where(i => i.Product.ProductBase.ProductBrandId == options.ProductBrandId);
            };

            var pagedInventory = await query
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
                .OrderBy(l => l.ProductBaseCode)
                .GetPagedAsync(options.CurrentPage, options.PageSize);

            return new LocationInventoryListRequest.Response(locationName, pagedInventory);
        }
    }
}
