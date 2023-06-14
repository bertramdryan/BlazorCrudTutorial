using BlazorCrudDotNet7.Server.Services.ProductService;
using BlazorCrudDotNet7.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlazorCrudDotNet7.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly IProductService _productService;

        public CategoryController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Category>>> GetCategories()
        {
            var categories = await _productService.GetCategories();
            if (categories == null)
            {
                return NotFound();
            }

            return Ok(categories);
        }
    }
}
