using agora_shop.Models;
using Microsoft.AspNetCore.Mvc;
namespace agora_shop.Controllers;

[ApiController]
[Route("api/products")]
public class ProductsController : ControllerBase
{
    [HttpGet]
    public IActionResult GetAllProducts()
    {
        return Ok(new { Products = new List<Product>()});
    }
}