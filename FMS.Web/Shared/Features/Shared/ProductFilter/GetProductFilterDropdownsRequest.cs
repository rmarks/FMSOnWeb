using MediatR;

namespace FMS.Web.Shared.Features.Shared.ProductFilter
{
    public record GetProductFilterDropdownsRequest : IRequest<GetProductFilterDropdownsRequest.Response>
    {
        public const string RouteTemplate = "api/product/dropdowns";

        public record Response(ProductFilterDropdownsVm Dropdowns);
    }
}
