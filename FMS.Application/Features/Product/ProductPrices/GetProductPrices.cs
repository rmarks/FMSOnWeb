using FMS.DAL;
using FMS.Web.Shared.Features.Product;
using MediatR;
namespace FMS.Application.Features.Product.ProductPrices
{
    public static class GetProductPrices
    {
        public record Query(int ProductBaseId, int PriceListId) : IRequest<IEnumerable<ProductPriceItemDto>>;

        public class Handler : IRequestHandler<Query, IEnumerable<ProductPriceItemDto>>
        {
            private readonly FMSContext _context;

            public Handler(FMSContext context)
            {
                _context = context;
            }

            public async Task<IEnumerable<ProductPriceItemDto>> Handle(Query request, CancellationToken cancellationToken)
            {
                return await _context.Prices
                    .AsNoTracking()
                    .Where(p => p.Product.ProductBaseId == request.ProductBaseId && p.PriceListId == request.PriceListId)
                    .Select(p => new ProductPriceItemDto
                    {
                        Id = p.Id,
                        ProductId = p.ProductId,
                        ProductCode = p.Product.Code,
                        UnitPrice = p.UnitPrice,
                        PriceListId = p.PriceListId
                    })
                    .ToListAsync();
            }
        }
    }
}
