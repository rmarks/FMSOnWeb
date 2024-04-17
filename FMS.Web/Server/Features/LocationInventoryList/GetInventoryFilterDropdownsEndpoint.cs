using FastEndpoints;
using FMS.DAL;
using FMS.Web.Shared.Features.LocationInventoryList;
using FMS.Web.Shared.Features.Shared;
using Microsoft.EntityFrameworkCore;

namespace FMS.Web.Server.Features.LocationInventoryList;

public class GetInventoryFilterDropdownsEndpoint : EndpointWithoutRequest<InventoryFilterDropdownsVm>
{
    private readonly FMSContext _context;

    public GetInventoryFilterDropdownsEndpoint(FMSContext context)
    {
        _context = context;
    }

    public override void Configure()
    {
        Get("api/locationinventory/dropdowns");
        AllowAnonymous();
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        Response = new InventoryFilterDropdownsVm
        {
            ProductStatuses = await _context.ProductStatuses
                    .AsNoTracking()
                    //.Select(p => new DropdownDto
                    //{
                    //    Id = p.Id,
                    //    Name = p.Name
                    //})
                    .Select(p => new DropdownVm(p.Id, p.Name))
                    .ToListAsync(),

            ProductMaterials = await _context.ProductMaterials
                    .AsNoTracking()
                    //.Select(p => new DropdownDto
                    //{
                    //    Id = p.Id,
                    //    Name = p.Name
                    //})
                    .Select(p => new DropdownVm(p.Id, p.Name))
                    .ToListAsync(),

            ProductSourceTypes = await _context.ProductSourceTypes
                    .AsNoTracking()
                    //.Select(p => new DropdownDto
                    //{
                    //    Id = p.Id,
                    //    Name = p.Name
                    //})
                    .Select(p => new DropdownVm(p.Id, p.Name))
                    .ToListAsync(),

            ProductDestinationTypes = await _context.ProductDestinationTypes
                    .AsNoTracking()
                    //.Select(p => new DropdownDto
                    //{
                    //    Id = p.Id,
                    //    Name = p.Name
                    //})
                    .Select(p => new DropdownVm(p.Id, p.Name))
                    .ToListAsync(),

            ProductTypes = await _context.ProductTypes
                    .AsNoTracking()
                    //.Select(p => new DropdownDto
                    //{
                    //    Id = p.Id,
                    //    Name = p.Name
                    //})
                    .Select(p => new DropdownVm(p.Id, p.Name))
                    .ToListAsync(),

            ProductGroups = await _context.ProductGroups
                    .AsNoTracking()
                    //.Select(p => new ChildDropdownDto
                    //{
                    //    Id = p.Id,
                    //    Name = p.Name,
                    //    ParentId = p.ProductTypeId
                    //})
                    .Select(p => new ChildDropdownVm(p.Id, p.Name, p.ProductTypeId))
                    .ToListAsync(),

            ProductBrands = await _context.ProductBrands
                    .AsNoTracking()
                    //.Select(p => new DropdownDto
                    //{
                    //    Id = p.Id,
                    //    Name = p.Name
                    //})
                    .Select(p => new DropdownVm(p.Id, p.Name))
                    .ToListAsync(),

            ProductCollections = await _context.ProductCollections
                    .AsNoTracking()
                    //.Select(p => new ChildDropdownDto
                    //{
                    //    Id = p.Id,
                    //    Name = p.Name,
                    //    ParentId = p.ProductBrandId
                    //})
                    .Select(p => new ChildDropdownVm(p.Id, p.Name, p.ProductBrandId))
                    .ToListAsync()
        };
    }
}
