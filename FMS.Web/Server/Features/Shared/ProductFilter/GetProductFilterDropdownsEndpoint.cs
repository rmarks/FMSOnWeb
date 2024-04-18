using FastEndpoints;
using FMS.DAL;
using FMS.Web.Shared.Features.Shared.Dropdowns;
using FMS.Web.Shared.Features.Shared.ProductFilter;
using Microsoft.EntityFrameworkCore;

namespace FMS.Web.Server.Features.Shared.ProductFilter
{
    public class GetProductFilterDropdownsEndpoint : EndpointWithoutRequest<GetProductFilterDropdownsRequest.Response>
    {
        private readonly FMSContext _context;

        public GetProductFilterDropdownsEndpoint(FMSContext context)
        {
            _context = context;
        }

        public override void Configure()
        {
            Get(GetProductFilterDropdownsRequest.RouteTemplate);
            AllowAnonymous();
        }

        public override async Task HandleAsync(CancellationToken ct)
        {
            var dropdowns = new ProductFilterDropdownsVm
            {
                ProductStatuses = await _context.ProductStatuses
                    .AsNoTracking()
                    .Select(p => new DropdownVm(p.Id, p.Name))
                    .ToListAsync(),

                ProductMaterials = await _context.ProductMaterials
                    .AsNoTracking()
                    .Select(p => new DropdownVm(p.Id, p.Name))
                    .ToListAsync(),

                ProductSourceTypes = await _context.ProductSourceTypes
                    .AsNoTracking()
                    .Select(p => new DropdownVm(p.Id, p.Name))
                    .ToListAsync(),

                ProductDestinationTypes = await _context.ProductDestinationTypes
                    .AsNoTracking()
                    .Select(p => new DropdownVm(p.Id, p.Name))
                    .ToListAsync(),

                ProductTypes = await _context.ProductTypes
                    .AsNoTracking()
                    .Select(p => new DropdownVm(p.Id, p.Name))
                    .ToListAsync(),

                ProductGroups = await _context.ProductGroups
                    .AsNoTracking()
                    .Select(p => new ChildDropdownVm(p.Id, p.Name, p.ProductTypeId))
                    .ToListAsync(),

                ProductBrands = await _context.ProductBrands
                    .AsNoTracking()
                    .Select(p => new DropdownVm(p.Id, p.Name))
                    .ToListAsync(),

                ProductCollections = await _context.ProductCollections
                    .AsNoTracking()
                    .Select(p => new ChildDropdownVm(p.Id, p.Name, p.ProductBrandId))
                    .ToListAsync()
            };

            Response = new GetProductFilterDropdownsRequest.Response(dropdowns);
        }
    }
}
