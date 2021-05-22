using Ardalis.ApiEndpoints;
using FMS.DAL;
using FMS.Web.Shared.Features.Product;
using FMS.Web.Shared.Features.Shared;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace FMS.Web.Server.Features.Product
{
    public class ProductVariantsDropdownsEndpoint : BaseAsyncEndpoint.WithoutRequest.WithResponse<ProductVariantsDropdowns>
    {
        private readonly FMSContext _context;

        public ProductVariantsDropdownsEndpoint(FMSContext context)
        {
            _context = context;
        }

        [HttpGet("api/product/productvariantsdropdowns")]
        public override async Task<ActionResult<ProductVariantsDropdowns>> HandleAsync(CancellationToken cancellationToken = default)
        {
            return new ProductVariantsDropdowns
            {
                ProductVariantTypes = await _context.ProductVariantTypes
                    .AsNoTracking()
                    .Select(p => new DropdownDto
                    {
                        Id = p.Id,
                        Name = p.Name
                    })
                    .ToListAsync()
            };
        }
    }
}
