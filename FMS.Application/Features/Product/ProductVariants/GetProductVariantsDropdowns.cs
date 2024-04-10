using FMS.Web.Shared.Features.Product;
using FMS.Web.Shared.Features.Shared;

namespace FMS.Application.Features.Product.ProductVariants
{
    public static class GetProductVariantsDropdowns
    {
        public record Query : IRequest<ProductVariantsDropdowns>;

        public class Handler : IRequestHandler<Query, ProductVariantsDropdowns>
        {
            private readonly FMSContext _context;

            public Handler(FMSContext context)
            {
                _context = context;
            }

            public async Task<ProductVariantsDropdowns> Handle(Query request, CancellationToken cancellationToken)
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
}
