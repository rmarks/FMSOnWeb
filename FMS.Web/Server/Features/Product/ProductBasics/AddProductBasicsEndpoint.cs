using FastEndpoints;
using FMS.DAL;
using FMS.Domain.Models;
using FMS.Web.Shared.Features.Product.ProductBasics;
using Mapster;

namespace FMS.Web.Server.Features.Product.ProductBasics;

public class AddProductBasicsEndpoint : Endpoint<AddProductBasicsRequest, AddProductBasicsRequest.Response>
{
    private readonly FMSContext _context;

    public AddProductBasicsEndpoint(FMSContext context)
    {
        _context = context;
    }

    public override void Configure()
    {
        Post(AddProductBasicsRequest.RouteTemplate);
        AllowAnonymous();
    }

    public override async Task HandleAsync(AddProductBasicsRequest req, CancellationToken ct)
    {
        var productBase = req.ProductBasics.Adapt<ProductBase>();
        await _context.AddAsync(productBase);
        await _context.SaveChangesAsync();

        await SendCreatedAtAsync<GetProductBasicsEndpoint>(new { id = productBase.Id }, new AddProductBasicsRequest.Response(productBase.Id));
    }
}
