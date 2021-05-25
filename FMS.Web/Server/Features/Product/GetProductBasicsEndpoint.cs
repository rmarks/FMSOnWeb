using Ardalis.ApiEndpoints;
using FMS.DAL;
using FMS.Web.Shared.Features.Product;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace FMS.Web.Server.Features.Product
{
    public class GetProductBasicsEndpoint : BaseAsyncEndpoint.WithRequest<int>.WithResponse<GetProductBasicsRequest.Response>
    {
        private readonly FMSContext _context;

        public GetProductBasicsEndpoint(FMSContext context)
        {
            _context = context;
        }

        [HttpGet(GetProductBasicsRequest.RouteTemplate)]
        public override async Task<ActionResult<GetProductBasicsRequest.Response>> HandleAsync(int id, CancellationToken cancellationToken = default)
        {
            var productBasicsVm = await _context.ProductBases
                .AsNoTracking()
                .Where(p => p.Id == id)
                .Select(p => new ProductBasicsVm
                {
                    Id = p.Id,
                    Code = p.Code,
                    Name = p.Name,
                    Comments = p.Comments,
                    ProductStatusId = p.ProductStatusId,
                    ProductSourceTypeId = p.ProductSourceTypeId,
                    ProductDestinationTypeId = p.ProductDestinationTypeId,
                    ProductMaterialId = p.ProductMaterialId,
                    ProductTypeId = p.ProductTypeId,
                    ProductGroupId = p.ProductGroupId,
                    ProductBrandId = p.ProductBrandId,
                    ProductCollectionId = p.ProductCollectionId
                })
                .FirstOrDefaultAsync();

            return Ok(new GetProductBasicsRequest.Response(productBasicsVm));
        }
    }
}
