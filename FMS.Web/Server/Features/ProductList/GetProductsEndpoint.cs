using FastEndpoints;
using FMS.DAL;
using FMS.Web.Server.Extensions;
using FMS.Web.Shared.Features.ProductList;
using Microsoft.EntityFrameworkCore;

namespace FMS.Web.Server.Features.ProductList
{
    public class GetProductsEndpoint : Endpoint<GetProductsRequest, GetProductsRequest.Response>
    {
        private readonly FMSContext _context;

        public GetProductsEndpoint(FMSContext context)
        {
            _context = context;
        }

        public override void Configure()
        {
            Post(GetProductsRequest.RouteTemplate);
            AllowAnonymous();
        }

        public override async Task HandleAsync(GetProductsRequest req, CancellationToken ct)
        {
            var query = _context.ProductBases
                .AsNoTracking();

            if (req.Filter.ProductStatusId > 0)
            {
                query = query.Where(p => p.ProductStatusId == req.Filter.ProductStatusId);
            };

            if (req.Filter.ProductMaterialId > 0)
            {
                query = query.Where(p => p.ProductMaterialId == req.Filter.ProductMaterialId);
            };

            if (req.Filter.ProductSourceTypeId > 0)
            {
                query = query.Where(p => p.ProductSourceTypeId == req.Filter.ProductSourceTypeId);
            };

            if (req.Filter.ProductDestinationTypeId > 0)
            {
                query = query.Where(p => p.ProductDestinationTypeId == req.Filter.ProductDestinationTypeId);
            };

            if (req.Filter.ProductGroupId > 0)
            {
                query = query.Where(p => p.ProductGroupId == req.Filter.ProductGroupId);
            }
            else if (req.Filter.ProductTypeId > 0)
            {
                query = query.Where(p => p.ProductTypeId == req.Filter.ProductTypeId);
            };

            if (req.Filter.ProductCollectionId > 0)
            {
                query = query.Where(p => p.ProductCollectionId == req.Filter.ProductCollectionId);
            }
            else if (req.Filter.ProductBrandId > 0)
            {
                query = query.Where(p => p.ProductBrandId == req.Filter.ProductBrandId);
            };

            var pagedProducts = await query
                .OrderBy(p => p.Code)
                .Select(p => new ProductListItemVm(p.Id, p.Code, p.Name))
                .GetPagedAsync(req.Filter.CurrentPage, req.Filter.PageSize);

            Response = new GetProductsRequest.Response(pagedProducts);
        }
    }
}
