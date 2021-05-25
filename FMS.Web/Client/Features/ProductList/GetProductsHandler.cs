using FMS.Web.Shared.Features.ProductList;
using MediatR;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading;
using System.Threading.Tasks;

namespace FMS.Web.Client.Features.ProductList
{
    public class GetProductsHandler : IRequestHandler<GetProductsRequest, GetProductsRequest.Response>
    {
        private readonly HttpClient _http;

        public GetProductsHandler(HttpClient http)
        {
            _http = http;
        }

        public async Task<GetProductsRequest.Response> Handle(GetProductsRequest request, CancellationToken cancellationToken)
        {
            var response = await _http.PostAsJsonAsync(GetProductsRequest.RouteTemplate, request.Options);
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<GetProductsRequest.Response>();
            }
            else
            {
                return new GetProductsRequest.Response(null);
            }
        }
    }
}
