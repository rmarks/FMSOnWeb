using Ardalis.ApiEndpoints;
using FMS.DAL;
using FMS.Web.Server.Extensions;
using FMS.Web.Shared.Features.ProductList;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace FMS.Web.Server.Features.ProductList
{
    public class GetProductsEndpoint : BaseAsyncEndpoint.WithRequest<ProductFilterOptionsVm>.WithResponse<GetProductsRequest.Response>
    {
        private readonly FMSContext _context;

        public GetProductsEndpoint(FMSContext context)
        {
            _context = context;
        }

        [HttpPost(GetProductsRequest.RouteTemplate)]
        public override async Task<ActionResult<GetProductsRequest.Response>> HandleAsync(ProductFilterOptionsVm options, CancellationToken cancellationToken = default)
        {
            var query = _context.ProductBases
                .AsNoTracking();

            if (options.ProductStatusId > 0)
            {
                query = query.Where(p => p.ProductStatusId == options.ProductStatusId);
            };

            if (options.ProductMaterialId > 0)
            {
                query = query.Where(p => p.ProductMaterialId == options.ProductMaterialId);
            };

            if (options.ProductSourceTypeId > 0)
            {
                query = query.Where(p => p.ProductSourceTypeId == options.ProductSourceTypeId);
            };

            if (options.ProductDestinationTypeId > 0)
            {
                query = query.Where(p => p.ProductDestinationTypeId == options.ProductDestinationTypeId);
            };

            if (options.ProductGroupId > 0)
            {
                query = query.Where(p => p.ProductGroupId == options.ProductGroupId);
            }
            else if (options.ProductTypeId > 0)
            {
                query = query.Where(p => p.ProductTypeId == options.ProductTypeId);
            };

            if (options.ProductCollectionId > 0)
            {
                query = query.Where(p => p.ProductCollectionId == options.ProductCollectionId);
            }
            else if (options.ProductBrandId > 0)
            {
                query = query.Where(p => p.ProductBrandId == options.ProductBrandId);
            };

            var pagedProducts = await query
                .OrderBy(p => p.Code)
                .Select(p => new ProductLisItemVm
                {
                    Id = p.Id,
                    Code = p.Code,
                    Name = p.Name
                })
                .GetPagedAsync(options.CurrentPage, options.PageSize);

            return Ok(new GetProductsRequest.Response(pagedProducts));
        }
    }
}
