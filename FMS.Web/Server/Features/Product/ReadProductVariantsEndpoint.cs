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
    public class ReadProductVariantsEndpoint : BaseAsyncEndpoint.WithRequest<int>.WithResponse<ProductVariantsDto>
    {
        private readonly FMSContext _context;

        public ReadProductVariantsEndpoint(FMSContext context)
        {
            _context = context;
        }

        [HttpGet("api/product/productvariants/{id}")]
        public override async Task<ActionResult<ProductVariantsDto>> HandleAsync(int id, CancellationToken cancellationToken = default)
        {
            return await _context.ProductBases
                .AsNoTracking()
                .Where(pb => pb.Id == id)
                .Select(pb => new ProductVariantsDto
                {
                    Id = pb.Id,
                    ProductVariantTypeId = pb.ProductVariantTypeId,
                    Products = pb.Products
                        .OrderBy(p => p.Code)
                        .Select(p => new ProductVariantsDto.ProductDto
                        {
                            Id = p.Id,
                            Code = p.Code,
                            Name = p.Name,
                            ProductBaseId = pb.Id
                        })
                        .ToList()
                })
                .FirstOrDefaultAsync();
        }
    }
}
