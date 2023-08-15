using System.Net.Http.Json;
using BlazorClient.models.system;
using BlazorClient.models.DTOs;
using BlazorClient.services.contracts;

namespace BlazorClient.services
{
    public class ProductService:IProductService
    {
        private readonly HttpClient httpClient;
        public ProductService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task <Response<IEnumerable<ProductDto>>> GetItems()
        {
            try
            {
                var products = await this.httpClient.GetFromJsonAsync<Response<IEnumerable<ProductDto>>>("api/Product/get");
                return products;
            }
            catch (System.Exception)
            {
                
                throw;
            }
        }
    }
}