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
    public class ReadProductBasicsEndpoint : BaseAsyncEndpoint.WithRequest<int>.WithResponse<ProductBasicsDto>
    {
        private readonly FMSContext _context;

        public ReadProductBasicsEndpoint(FMSContext context)
        {
            _context = context;
        }

        [HttpGet("api/productbasics/{id}")]
        public override async Task<ActionResult<ProductBasicsDto>> HandleAsync(int id, CancellationToken cancellationToken = default)
        {
            return await _context.ProductBases
                .AsNoTracking()
                .Where(p => p.Id == id)
                .Select(p => new ProductBasicsDto
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
        }
    }
}
