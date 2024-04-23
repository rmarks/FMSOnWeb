using FastEndpoints;
using FMS.DAL;
using FMS.Web.Shared.Features.Product.ProductBasics;

namespace FMS.Web.Server.Features.Product.ProductBasics;

public class UpdateProductBasicsEndpoint : Endpoint<UpdateProductBasicsRequest>
{
    private readonly FMSContext _context;

    public UpdateProductBasicsEndpoint(FMSContext context)
    {
        _context = context;
    }

    public override void Configure()
    {
        Put(UpdateProductBasicsRequest.RouteTemplate);
        AllowAnonymous();
    }

    public override async Task HandleAsync(UpdateProductBasicsRequest req, CancellationToken ct)
    {
        if (req.Id != req.ProductBasics.Id) await SendErrorsAsync();

        var productBase = await _context.ProductBases.FindAsync(req.ProductBasics.Id);
        
        if (productBase is null) await SendNotFoundAsync();

        _context.Entry(productBase!).CurrentValues.SetValues(req.ProductBasics);
        await _context.SaveChangesAsync();

        await SendNoContentAsync();
    }
}
