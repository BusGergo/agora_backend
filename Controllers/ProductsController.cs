using agora_shop.Models;
using agora_shop.Services.IServices;
using Microsoft.AspNetCore.Mvc;
namespace agora_shop.Controllers;

[ApiController]
[Route("api/products")]
public class ProductsController : ControllerBase
{
    IProductsService _productsService;

    public ProductsController(IProductsService productsService)
    {
        _productsService = productsService;
    }
    
    [HttpGet]
    public IActionResult GetAllProducts()
    {
        return Ok(new { Products = new List<Product>()});
    }
}