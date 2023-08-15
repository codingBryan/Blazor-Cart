using BlazorClient.models.system;
using BlazorClient.models.DTOs;

namespace BlazorClient.services.contracts
{
    public interface IProductService
    {
        Task <Response<IEnumerable<ProductDto>>> GetItems();
    }
}