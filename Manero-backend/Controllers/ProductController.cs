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
        public IActionResult Get()
        {
            return Ok("Hello World");
        }
    }
}
