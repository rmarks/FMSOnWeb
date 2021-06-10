using FMS.DAL;
using FMS.Web.Shared.Features.Product;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace FMS.Application.Features.Product.ProductBasics
{
    public static class UpdateProductBasics
    {
        public record Command(ProductBasicsDto ProductBasicsDto) : IRequest<bool>;

        public class Handler : IRequestHandler<Command, bool>
        {
            private readonly FMSContext _context;

            public Handler(FMSContext context)
            {
                _context = context;
            }

            public async Task<bool> Handle(Command request, CancellationToken cancellationToken)
            {
                var productBase = await _context.ProductBases.FindAsync(request.ProductBasicsDto.Id);

                _context.Entry(productBase).CurrentValues.SetValues(request.ProductBasicsDto);

                await _context.SaveChangesAsync();

                return true;
            }
        }
    }
}
