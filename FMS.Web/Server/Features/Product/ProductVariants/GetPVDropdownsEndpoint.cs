using FastEndpoints;
using FMS.DAL;
using FMS.Web.Shared.Features.Product.ProductVariants;
using FMS.Web.Shared.Features.Shared.Dropdowns;
using Microsoft.EntityFrameworkCore;

namespace FMS.Web.Server.Features.Product.ProductVariants;

public class GetPVDropdownsEndpoint : EndpointWithoutRequest<GetPVDropdownsRequest.Response>
{
    private readonly FMSContext _context;

    public GetPVDropdownsEndpoint(FMSContext context)
    {
        _context = context;
    }

    public override void Configure()
    {
        Get(GetPVDropdownsRequest.RouteTemplate);
        AllowAnonymous();
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        var productVariantTypes = await _context.ProductVariantTypes
            .AsNoTracking()
            .Select(p => new DropdownVm(p.Id, p.Name))
            .ToListAsync();

        Response = new GetPVDropdownsRequest.Response(productVariantTypes);
    }
}
