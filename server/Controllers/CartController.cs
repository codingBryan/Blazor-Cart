using Microsoft.AspNetCore.Mvc;
using server.entities.models;
using server.entities.DTOs;
using server.Extensions;
using server.Repositories.ProductRepo;

namespace server.Controllers;

[ApiController]
[Route("[controller]")]
public class CartController : ControllerBase
{
    private readonly IProductRepository productRepo;
    public CartController(IProductRepository productRepo)
    {
        this.productRepo = productRepo;
    }
    [HttpGet(Name = "GetProducts")]
    public async Task<ActionResult<IEnumerable<ProductDto>>> GetItems()
    {
       try
       {
        var products = await this.productRepo.GetItems();
        var categories = await this.productRepo.GetCategories();
        if (products  is null || categories is null)
        {
            return NotFound();
        }else{
            var productDtos = products.ConvertToDto(categories);
            return Ok(productDtos);
        }
       }
       catch (System.Exception)
       {
        return StatusCode(StatusCodes.Status500InternalServerError,"Error occured while retrieving data from the database");
       }
    }
}
