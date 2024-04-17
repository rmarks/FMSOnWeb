using FMS.Web.Shared.Features.ProductList;
using MediatR;
using System.Net.Http.Json;

namespace FMS.Web.Client.Features.ProductList
{
    public class GetProductsHandler : IRequestHandler<GetProductsRequest, GetProductsRequest.Response>
    {
        private readonly HttpClient _httpClient;

        public GetProductsHandler(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<GetProductsRequest.Response> Handle(GetProductsRequest request, CancellationToken cancellationToken)
        {
            var httpResponse = await _httpClient.PostAsJsonAsync(GetProductsRequest.RouteTemplate, request);
            if (httpResponse.IsSuccessStatusCode)
            {
                return await httpResponse.Content.ReadFromJsonAsync<GetProductsRequest.Response>()
                    ?? new GetProductsRequest.Response(null);
            }
            else
            {
                return new GetProductsRequest.Response(null);
            }
        }
    }
}
