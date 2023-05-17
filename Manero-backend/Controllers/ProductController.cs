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

            var product = await _productService.GetProductByIdAsync(id);
            var serviceResponse = new ServiceResponse<ProductResponse>();

            if (product == null)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = "Product not found  \U0001f937‍♀️ ";
                return NotFound(serviceResponse);
            }
            else
            {
                serviceResponse.Data = product;
                return Ok(serviceResponse);
            }
        }


        // skapa en metod för search och filter som tar in en parameter och returnerar en lista med produkter som matchar sökningen och filtret och är asynkron
        // GET: api/Product/search
        [HttpGet("searchby")]
        public async Task<ActionResult<ServiceResponse<IEnumerable<ProductResponse>>>> GetProductBySearchAsync([FromQuery] string search)
        {
            //var productService = new ProductService();
            //_productService.GetProductBySearchAsync(x => x.Name == "hej");
            var product = await _productService.GetProductBySearchAsync(p => p.Name.Contains(search));

            var serviceResponse = new ServiceResponse<IEnumerable<ProductResponse>>();
            if (product == null)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = "Product not found  \U0001f937‍♀️ ";
                return NotFound(serviceResponse);
            }
            else
            {
                serviceResponse.Data = product;
                return Ok(serviceResponse);
            }
        }


        [HttpGet("search")]
        public async Task<ActionResult<List<ProductResponse>>> GetProductBySearchAndFilterAsync([FromQuery] SearchFilterCriteria criteria)
        {
            var products = await _productService.GetProductBySearchAndFilterAsync(criteria);

            if (products == null || !products.Any())
            {
                return NotFound("No products found.");
            }

            return Ok(products);
        }

        public IProductService Get_productService()
        {
            return _productService;
        }

        // DELETE: api/Product/{id}
        [HttpDelete("{id}")]
        public async Task<ActionResult<ServiceResponse<bool>>> DeleteProductAsync(int id, IProductService _productService)
        {
            try
            {
                var success = await _productService.DeleteProductAsync( id);
                var response = new ServiceResponse<bool>
                {
                    Data = success,
                    Message = success ? "Product deleted successfully" : "Product not found"
                };
                return Ok(response);
            }
            catch (Exception e)
            {
                return BadRequest(" OPPS \U0001fae3 \U0001fae2  : " + e.Message + "\U0001f937‍♀️");
            }
        }




    }
}
