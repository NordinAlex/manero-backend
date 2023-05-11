using Manero_backend.DTOs.Product;
using Manero_backend.Interfaces.Product.Services;
using Manero_backend.Migrations;
using Manero_backend.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
        public async Task<ActionResult<ServiceResponse<IEnumerable<ProductResponse>>>> GetAllProducts()
        {
            if (!ModelState.IsValid)
            {
                var response = new ServiceResponse<IEnumerable<ProductResponse>>
                {
                    Success = false,
                    Message = "Sorry 😒 Invalid model" + ModelState 
                };
                response.Extensions = new Dictionary<string, object>
                {
                    ["errors"] = ModelState.SelectMany(x => x.Value.Errors.Select(e => e.ErrorMessage)).ToList()
                };

                return BadRequest(response);
            }
            try
            {
                var product = await _productService.GetAllProductAsync();

                var response = new ServiceResponse<IEnumerable<ProductResponse>>
                {
                    Data = product
                };
               
                if (!product.Any()) // Kontrollera om listan med produkter är tom
                {
                    response.Message = "No products found in the database. 😱";
                }
                return Ok(response);
            }
            catch (Exception e)
            {
                return BadRequest(" OPPS \U0001fae3 \U0001fae2  : " + e.Message + "\U0001f937‍♀️");
            }

        }


        // POST: api/Product
        [HttpPost]
        public async Task<ActionResult<ServiceResponse<ProductResponse>>> CreateProduct([FromBody] ProductRequest productRequest)
        {

            if (!ModelState.IsValid)
            {
                var response = new ServiceResponse<IEnumerable<ProductResponse>>
                {
                    Success = false,
                    Message = "Sorry 😒 Invalid model" + ModelState
                };
                response.Extensions = new Dictionary<string, object>
                {
                    ["errors"] = ModelState.SelectMany(x => x.Value.Errors.Select(e => e.ErrorMessage)).ToList()
                };

                return BadRequest(response);
            }
            try
            {
                var product = await _productService.CreateProductAsync(productRequest);
                var response = new ServiceResponse<ProductResponse>
                {
                    Data = product
                };
                return Ok(response);
            }
            catch (DbUpdateException ex)
            {
                return BadRequest(" OPPS \U0001fae2  : " + ex.InnerException?.Message + " \U0001f937‍♀️");
            }

        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<ProductResponse>>> GetProductByIdAsync(int id)
        {
            var article = await _productService.GetProductByIdAsync(id);
            if (article == null) return NotFound();
            return Ok(article);
        }
    }
}
