using FMS.Web.Shared.Features.Product;
using FMS.Web.Shared.Features.Shared.Dropdowns;

namespace FMS.Application.Features.Product.ProductBasics;

public static class GetProductBasicsDropdowns
{
    public record Query : IRequest<ProductBasicsDropdowns>;

    public class Handler : IRequestHandler<Query, ProductBasicsDropdowns>
    {
        private readonly FMSContext _context;

        public Handler(FMSContext context)
        {
            _context = context;
        }

        public async Task<ProductBasicsDropdowns> Handle(Query request, CancellationToken cancellationToken)
        {
            return new ProductBasicsDropdowns
            {
                ProductStatuses = await _context.ProductStatuses
                .AsNoTracking()
                .Select(p => new DropdownDto
                {
                    Id = p.Id,
                    Name = p.Name
                })
                .ToListAsync(),

                ProductMaterials = await _context.ProductMaterials
                .AsNoTracking()
                .Select(p => new DropdownDto
                {
                    Id = p.Id,
                    Name = p.Name
                })
                .ToListAsync(),

                ProductSourceTypes = await _context.ProductSourceTypes
                .AsNoTracking()
                .Select(p => new DropdownDto
                {
                    Id = p.Id,
                    Name = p.Name
                })
                .ToListAsync(),

                ProductDestinationTypes = await _context.ProductDestinationTypes
                .AsNoTracking()
                .Select(p => new DropdownDto
                {
                    Id = p.Id,
                    Name = p.Name
                })
                .ToListAsync(),

                ProductTypes = await _context.ProductTypes
                .AsNoTracking()
                .Select(p => new DropdownDto
                {
                    Id = p.Id,
                    Name = p.Name
                })
                .ToListAsync(),

                ProductGroups = await _context.ProductGroups
                .AsNoTracking()
                .Select(p => new ChildDropdownDto
                {
                    Id = p.Id,
                    Name = p.Name,
                    ParentId = p.ProductTypeId
                })
                .ToListAsync(),

                ProductBrands = await _context.ProductBrands
                .AsNoTracking()
                .Select(p => new DropdownDto
                {
                    Id = p.Id,
                    Name = p.Name
                })
                .ToListAsync(),

                ProductCollections = await _context.ProductCollections
                .AsNoTracking()
                .Select(p => new ChildDropdownDto
                {
                    Id = p.Id,
                    Name = p.Name,
                    ParentId = p.ProductBrandId
                })
                .ToListAsync()
            };
        }
    }
}
