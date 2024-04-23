using FastEndpoints;
using FMS.DAL;
using FMS.Web.Shared.Features.Product.ProductBasics;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace FMS.Web.Server.Features.Product.ProductBasics;

public class GetProductBasicsEndpoint : Endpoint<GetProductBasicsRequest, GetProductBasicsRequest.Response>
{
    private readonly FMSContext _context;

    public GetProductBasicsEndpoint(FMSContext context)
    {
        _context = context;
    }

    public override void Configure()
    {
        Get(GetProductBasicsRequest.RouteTemplate);
        AllowAnonymous();
    }

    public override async Task HandleAsync(GetProductBasicsRequest req, CancellationToken ct)
    {
        var dto = await _context.ProductBases
            .AsNoTracking()
            .Where(p => p.Id == req.Id)
            .ProjectToType<ProductBasicsDto>()
            .FirstOrDefaultAsync();

        if (dto is null)
        {
            await SendResultAsync(TypedResults.NotFound());
        }
        else
        {
            Response = new GetProductBasicsRequest.Response(dto);
        }
    }
}
