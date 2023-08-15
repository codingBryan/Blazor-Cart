using Microsoft.AspNetCore.Components;
using BlazorClient.services.contracts;
using BlazorClient.models.system;
using BlazorClient.models.DTOs;

namespace BlazorClient.Pages
{
    public class ProductsBase:ComponentBase
    {
        [Inject]
        public IProductService service { get; set; }

        public Response<IEnumerable<ProductDto>> response { get; set; }

        protected override async Task OnInitializedAsync()
        {
            response = await service.GetItems();
        }
    }
}