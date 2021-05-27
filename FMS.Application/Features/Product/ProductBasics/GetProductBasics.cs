using FMS.DAL;
using FMS.Web.Shared.Features.Product;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace FMS.Application.Features.Product.ProductBasics
{
    public static class GetProductBasics
    {
        public record Query(int Id) : IRequest<ProductBasicsDto>;

        public class Handler : IRequestHandler<Query, ProductBasicsDto>
        {
            private readonly FMSContext _context;

            public Handler(FMSContext context)
            {
                _context = context;
            }

            public async Task<ProductBasicsDto> Handle(Query request, CancellationToken cancellationToken)
            {
                return await _context.ProductBases
                .AsNoTracking()
                .Where(p => p.Id == request.Id)
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
}
