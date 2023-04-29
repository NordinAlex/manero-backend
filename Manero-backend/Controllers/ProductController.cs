using Manero_backend.DTOs.Product;
using Manero_backend.Interfaces.Product.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Manero_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }


        // GET: api/Product
        [HttpGet]      
        public async Task<ActionResult<IEnumerable<ProductResponse>>> GetAllProducts()
        {
            var product = await _productService.GetAllProductAsync();
            return Ok(product);
        }

        // POST: api/Product
        [HttpPost]
        public async Task<ActionResult<ProductResponse>> CreateProduct([FromBody] ProductRequest productRequest)
        {
            var product = await _productService.CreateProductAsync(productRequest);
            return Ok(product);
        }
    }
}
