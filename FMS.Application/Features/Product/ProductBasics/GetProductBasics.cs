using FMS.Web.Shared.Features.Product;

namespace FMS.Application.Features.Product.ProductBasics
{
    public static class GetProductBasics
    {
        public record Query(int Id) : IRequest<ProductBasicsDto?>;

        public class Handler : IRequestHandler<Query, ProductBasicsDto?>
        {
            private readonly FMSContext _context;
            private readonly IMapper _mapper;

            public Handler(FMSContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<ProductBasicsDto?> Handle(Query request, CancellationToken cancellationToken)
            {
                return await _mapper
                    .ProjectTo<ProductBasicsDto>(_context.ProductBases.AsNoTracking().Where(p => p.Id == request.Id))
                    .FirstOrDefaultAsync();
            }
        }
    }
}
