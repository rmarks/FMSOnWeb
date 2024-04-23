using FastEndpoints;
using FMS.DAL;
using FMS.Web.Shared.Features.Product.ProductVariants;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace FMS.Web.Server.Features.Product.ProductVariants;

public class GetProductVariantsEndpoint : Endpoint<GetProductVariantsRequest, GetProductVariantsRequest.Response>
{
    private readonly FMSContext _context;

    public GetProductVariantsEndpoint(FMSContext context)
    {
        _context = context;
    }

    public override void Configure()
    {
        Get(GetProductVariantsRequest.RouteTemplate);
        AllowAnonymous();
    }

    public override async Task HandleAsync(GetProductVariantsRequest req, CancellationToken ct)
    {
        var response = await _context.ProductBases
            .AsNoTracking()
            .Where(pb => pb.Id == req.Id)
            //.ProjectToType<GetProductVariantsRequest.Response>()
            .Select(pb => new GetProductVariantsRequest.Response(
                pb.Id,
                pb.ProductVariantTypeId,
                pb.Products
                    .OrderBy(p => p.Code)
                    .Select(p => new GetProductVariantsRequest.ProductDto(p.Id, p.Code, p.Name, p.ProductBaseId))
                    .ToList()
            ))
            .FirstOrDefaultAsync();

        if (response is null)
        {
            await SendNotFoundAsync();
        }
        else
        {
            await SendOkAsync(response);
        }
    }
}
