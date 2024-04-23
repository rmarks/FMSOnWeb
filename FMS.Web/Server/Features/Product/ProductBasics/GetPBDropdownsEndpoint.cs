using FastEndpoints;
using FMS.DAL;
using FMS.Web.Shared.Features.Product.ProductBasics;
using FMS.Web.Shared.Features.Shared.Dropdowns;
using Microsoft.EntityFrameworkCore;

namespace FMS.Web.Server.Features.Product.ProductBasics;

public class GetPBDropdownsEndpoint : EndpointWithoutRequest<GetPBDropdownsRequest.Response>
{
    private readonly FMSContext _context;

    public GetPBDropdownsEndpoint(FMSContext context)
    {
        _context = context;
    }

    public override void Configure()
    {
        Get(GetPBDropdownsRequest.RouteTemplate);
        AllowAnonymous();
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        var dict = new Dictionary<string, IEnumerable<DropdownDto>>();

        var productStatuses = await _context.ProductStatuses
            .AsNoTracking()
            .Select(p => new DropdownDto(p.Id, p.Name, 0))
            .ToListAsync();
        dict.Add("ProductStatuses", productStatuses);

        var productMaterials = await _context.ProductMaterials
            .AsNoTracking()
            .Select(p => new DropdownDto(p.Id, p.Name, 0))
            .ToListAsync();
        dict.Add("ProductMaterials", productMaterials);

        var productSourceTypes = await _context.ProductSourceTypes
            .AsNoTracking()
            .Select(p => new DropdownDto(p.Id, p.Name, 0))
            .ToListAsync();
        dict.Add("ProductSourceTypes", productSourceTypes);

        var productDestinationTypes = await _context.ProductDestinationTypes
            .AsNoTracking()
            .Select(p => new DropdownDto(p.Id, p.Name, 0))
            .ToListAsync();
        dict.Add("ProductDestinationTypes", productDestinationTypes);

        var productTypes = await _context.ProductTypes
            .AsNoTracking()
            .Select(p => new DropdownDto(p.Id, p.Name, 0))
            .ToListAsync();
        dict.Add("ProductTypes", productTypes);

        var productGroups = await _context.ProductGroups
            .AsNoTracking()
            .Select(p => new DropdownDto(p.Id, p.Name, p.ProductTypeId))
            .ToListAsync();
        dict.Add("ProductGroups", productGroups);

        var productBrands = await _context.ProductBrands
            .AsNoTracking()
            .Select(p => new DropdownDto(p.Id, p.Name, 0))
            .ToListAsync();
        dict.Add("ProductBrands", productBrands);

        var productCollections = await _context.ProductCollections
            .AsNoTracking()
            .Select(p => new DropdownDto(p.Id, p.Name, p.ProductBrandId))
            .ToListAsync();
        dict.Add("ProductCollections", productCollections);

        Response = new GetPBDropdownsRequest.Response(dict);
    }
}
