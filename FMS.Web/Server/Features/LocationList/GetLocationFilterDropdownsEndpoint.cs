using FastEndpoints;
using FMS.DAL;
using FMS.Web.Shared.Features.Shared;
using Microsoft.EntityFrameworkCore;

namespace FMS.Web.Server.Features.LocationList;

public class GetLocationFilterDropdownsEndpoint : EndpointWithoutRequest<IEnumerable<DropdownVm>>
{
    private readonly FMSContext _context;

    public GetLocationFilterDropdownsEndpoint(FMSContext context)
    {
        _context = context;
    }

    public override void Configure()
    {
        Get("/api/locations/dropdowns");
        AllowAnonymous();
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        Response = await _context.LocationTypes
            .AsNoTracking()
            .Select(lt => new DropdownVm(lt.Id, lt.Name))
            .ToListAsync();
    }
}
