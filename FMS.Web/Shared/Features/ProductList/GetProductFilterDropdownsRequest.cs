using MediatR;

namespace FMS.Web.Shared.Features.ProductList
{
    public record GetProductFilterDropdownsRequest : IRequest<GetProductFilterDropdownsRequest.Response>
    {
        public const string RouteTemplate = "api/products/dropdowns";

        public record Response(ProductFilterDropdownsVm Dropdowns);
    }
}
