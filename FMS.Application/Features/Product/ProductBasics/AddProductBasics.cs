using AutoMapper;
using FMS.DAL;
using FMS.Domain.Models;
using FMS.Web.Shared.Features.Product;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace FMS.Application.Features.Product.ProductBasics
{
    public static class AddProductBasics
    {
        public record Command(ProductBasicsDto Dto) : IRequest<ProductBasicsDto>;

        public class Handler : IRequestHandler<Command, ProductBasicsDto>
        {
            private readonly FMSContext _context;
            private readonly IMapper _mapper;

            public Handler(FMSContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<ProductBasicsDto> Handle(Command request, CancellationToken cancellationToken)
            {
                //var productBase = new ProductBase();
                //var entry = await _context.AddAsync(productBase);
                //entry.CurrentValues.SetValues(request.Dto);
                var productBase = _mapper.Map<ProductBase>(request.Dto);
                await _context.AddAsync(productBase);
                await _context.SaveChangesAsync();

                return _mapper.Map<ProductBasicsDto>(productBase);
            }
        }
    }
}
