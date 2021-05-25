using MediatR;

namespace FMS.Web.Shared.Features.Product
{
    public record GetProductBasicsRequest(int Id) : IRequest<GetProductBasicsRequest.Response>
    {
        public const string RouteTemplate = "api/product/productbasics/{id}";

        public record Response(ProductBasicsVm ProductBasicsVm);
    }
}
