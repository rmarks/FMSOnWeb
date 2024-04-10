using Ardalis.ApiEndpoints;
using FMS.DAL;
using FMS.Web.Shared.Features.LocationInventoryList;
using FMS.Web.Shared.Features.Shared;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FMS.Web.Server.Features.LocationInventoryList
{
    public class InventoryFilterDropdownsEndpoint : BaseAsyncEndpoint.WithoutRequest.WithResponse<InventoryFilterDropdowns>
    {
        private readonly FMSContext _context;

        public InventoryFilterDropdownsEndpoint(FMSContext context)
        {
            _context = context;
        }

        [HttpGet("api/locationinventory/dropdowns")]
        public override async Task<ActionResult<InventoryFilterDropdowns>> HandleAsync(CancellationToken cancellationToken = default)
        {
            return new InventoryFilterDropdowns
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
