using Ardalis.ApiEndpoints;
using FMS.DAL;
using FMS.Web.Shared.Features.ProductList;
using FMS.Web.Shared.Features.Shared;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FMS.Web.Server.Features.ProductList
{
    public class GetProductFilterDropdownsEndpoint : BaseAsyncEndpoint.WithoutRequest.WithResponse<GetProductFilterDropdownsRequest.Response>
    {
        private readonly FMSContext _context;

        public GetProductFilterDropdownsEndpoint(FMSContext context)
        {
            _context = context;
        }

        [HttpGet(GetProductFilterDropdownsRequest.RouteTemplate)]
        public override async Task<ActionResult<GetProductFilterDropdownsRequest.Response>> HandleAsync(CancellationToken cancellationToken = default)
        {
            var dropdowns = new ProductFilterDropdownsVm
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

            return Ok(new GetProductFilterDropdownsRequest.Response(dropdowns));
        }
    }
}
