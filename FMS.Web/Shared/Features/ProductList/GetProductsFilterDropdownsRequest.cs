using MediatR;

namespace FMS.Web.Shared.Features.ProductList
{
    public record GetProductsFilterDropdownsRequest : IRequest<GetProductsFilterDropdownsRequest.Response>
    {
        public const string RouteTemplate = "api/product/dropdowns";

        public record Response(ProductListFilterDropdownsVm Dropdowns);
    }
}
