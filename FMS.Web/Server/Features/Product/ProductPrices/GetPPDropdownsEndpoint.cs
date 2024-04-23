using FastEndpoints;
using FMS.DAL;
using FMS.Web.Shared.Features.Product.ProductPrices;
using FMS.Web.Shared.Features.Shared.Dropdowns;
using Microsoft.EntityFrameworkCore;

namespace FMS.Web.Server.Features.Product.ProductPrices;

public class GetPPDropdownsEndpoint : EndpointWithoutRequest<GetPPDropdownsRequest.Response>
{
    private readonly FMSContext _context;

    public GetPPDropdownsEndpoint(FMSContext context)
    {
        _context = context;
    }

    public override void Configure()
    {
        Get(GetPPDropdownsRequest.RouteTemplate);
        AllowAnonymous();
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        var priceLists = await _context.PriceLists
            .AsNoTracking()
            .OrderBy(p => p.Name)
            .Select(p => new DropdownVm(p.Id, p.Name))
            .ToListAsync();

        Response = new GetPPDropdownsRequest.Response(priceLists);
    }
}
