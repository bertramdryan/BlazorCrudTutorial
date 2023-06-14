using BlazorCrudDotNet7.Server.Services.ProductService;
using BlazorCrudDotNet7.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlazorCrudDotNet7.Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductController : ControllerBase
{
    private readonly IProductService _productService;

    public ProductController(IProductService productService)
    {
        _productService = productService;
    }


    [HttpGet]
    public async Task<ActionResult<List<Product>>> GetProducts()
    {
        var products = await _productService.GetProducts();

        if (products == null)
        {
            return NotFound();
        }

        return Ok(products);
    }

    [HttpPost]
    public async Task<ActionResult<Product>> CreateNewProject(Product product)
    {
        var newProdoct = await _productService.CreateProduct(product);

        if (newProdoct == null)
        {
            return BadRequest($"Something went wrong saving {product.Title}");
        }

        return Ok(newProdoct);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Product>> GetProductById(int id)
    {
        var product = await _productService.GetProductById(id);
        if (product == null)
        {
            return NotFound();
        }

        return Ok(product);
    }


    [HttpPut]
    public async Task<ActionResult<Product>> UpdateProduct(Product product)
    {
        var updatedProduct = await _productService.UpdateProduct(product);
        if (updatedProduct == null)
        {
            return NotFound();
        }
        return Ok(updatedProduct);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteProduct(int id)
    {
        await _productService.DeleteProduct(id);

        return NoContent();
    }


}

