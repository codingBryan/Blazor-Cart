namespace server.Controllers;
using server.entities.system;
using server.entities.DTOs;

[ApiController]
[Route("api/[controller]")]
public class ProductController : ControllerBase
{
    private readonly IProductRepository productRepo;
    public ProductController(IProductRepository productRepo)
    {
        this.productRepo = productRepo;
    }

    [HttpGet("get")]
    public async Task<ActionResult<Response<IEnumerable<ProductDto>>>> GetItems()
    {
        Response<IEnumerable<ProductDto>> res = new Response<IEnumerable<ProductDto>>();
        try
        {
            var products = await this.productRepo.GetItems();
            var categories = await this.productRepo.GetCategories();
            if (products  is null || categories is null)
            {
                res.success = false;
                return NotFound();
            }else{
                var productDtos = products.ConvertToDto(categories);
                res.data = productDtos;
                res.message = "Successfully fetched products";
                return Ok(res);
            }
        }
        catch (System.Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError,"Error occured while retrieving data from the database");
        }
    }

    // [HttpGet("GetProductById")]
    // public async Task<ActionResult<Respone<ProductDto>>> GetItemById(int ProductId,int CategoryId)
    // {
    //     Respone<ProductDto> res = new Respone<ProductDto>();
    //     try
    //     {
    //         Product product = await this.productRepo.GetItem(ProductId);
    //         Category category = await this.productRepo.GetCategory(CategoryId)
    //     }
    //     catch (System.Exception)
    //     {
            
    //         throw;
    //     }
    // }
}
