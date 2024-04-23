using FastEndpoints;
using FMS.DAL;
using FMS.Web.Shared.Features.Product.ProductPrices;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace FMS.Web.Server.Features.Product.ProductPrices;

public class GetProductPricesEndpoint : Endpoint<GetProductPricesRequest, GetProductPricesRequest.Response>
{
    private readonly FMSContext _context;

    public GetProductPricesEndpoint(FMSContext context)
    {
        _context = context;
    }

    public override void Configure()
    {
        Get(GetProductPricesRequest.RouteTemplate);
        AllowAnonymous();
    }

    public override async Task HandleAsync(GetProductPricesRequest req, CancellationToken ct)
    {
        var productPrices = await _context.Prices
            .AsNoTracking()
            .Where(p => p.Product.ProductBaseId == req.ProductBaseId && p.PriceListId == req.PriceListId)
            .OrderBy(p => p.Product.Code)
            .ProjectToType<GetProductPricesRequest.ProductPriceDto>()
            .ToListAsync();

        if (productPrices is null)
        {
            await SendNotFoundAsync();
        }
        else
        {
            Response = new GetProductPricesRequest.Response(productPrices);
        }
    }
}
