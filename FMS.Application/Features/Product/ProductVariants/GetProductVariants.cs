using FMS.Web.Shared.Features.Product;

namespace FMS.Application.Features.Product.ProductVariants
{
    public static class GetProductVariants
    {
        public record Query(int Id) : IRequest<ProductVariantsDto?>;

        public class Handler : IRequestHandler<Query, ProductVariantsDto?>
        {
            private readonly FMSContext _context;

            public Handler(FMSContext context)
            {
                _context = context;
            }

            public async Task<ProductVariantsDto?> Handle(Query request, CancellationToken cancellationToken)
            {
                return await _context.ProductBases
                .AsNoTracking()
                .Where(pb => pb.Id == request.Id)
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
}
