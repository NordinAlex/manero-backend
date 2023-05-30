using Manero_backend.DTOs.Product;
using Manero_backend.Interfaces.Product.Services;
using Manero_backend.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Manero_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilterController : ControllerBase
    {
        private readonly ISearchFilterService _searchFilterService;

        public FilterController(ISearchFilterService searchFilterService)
        {
            _searchFilterService = searchFilterService;
        }
        // Skapa en metod som visar alla tags som finns i databasen (GET) 
        [HttpGet("tags")]
        public async Task<ActionResult<ServiceResponse<IEnumerable<TagResponse>>>> GetAllTags()
        {
            try
            {
                var tags = await _searchFilterService.GetAllTagAsync();
                var response = new ServiceResponse<IEnumerable<TagResponse>>
                {
                    Data = tags
                };
                if (!tags.Any()) // Kontrollera om listan med produkter är tom
                {
                    response.Message = "No tags found in the database. 😱";
                }
                return Ok(response);
            }
            catch (Exception e)
            {
                return BadRequest("Error occurred during search and filter \U0001f937‍♀️: " + e.Message);
            }
        }

        [HttpGet("brand")]
        public async Task<ActionResult<ServiceResponse<IEnumerable<BrandResponse>>>> GetAllTBrand()
        {
            try
            {
                var brand = await _searchFilterService.GetAlBrandAsync();
                var response = new ServiceResponse<IEnumerable<BrandResponse>>
                {
                    Data = brand
                };
                if (!brand.Any()) // Kontrollera om listan med produkter är tom
                {
                    response.Message = "No tags found in the database. 😱";
                }
                return Ok(response);
            }
            catch (Exception e)
            {
                return BadRequest("Error occurred during search and filter \U0001f937‍♀️: " + e.Message);
            }
        }
        [HttpGet("color")]
        public async Task<ActionResult<ServiceResponse<IEnumerable<ColorResponse>>>> GetAllColor()
        {
            try
            {
                var color = await _searchFilterService.GetAllColorAsync();
                var response = new ServiceResponse<IEnumerable<ColorResponse>>
                {
                    Data = color
                };
                if (!color.Any()) // Kontrollera om listan med produkter är tom
                {
                    response.Message = "No tags found in the database. 😱";
                }
                return Ok(response);
            }
            catch (Exception e)
            {
                return BadRequest("Error occurred during search and filter \U0001f937‍♀️: " + e.Message);
            }
        }
        [HttpGet("Size")]
        public async Task<ActionResult<ServiceResponse<IEnumerable<SizeResponse>>>> GetAllSize()
        {
            try
            {
                var sizes = await _searchFilterService.GetAllSizeAsync();
                var response = new ServiceResponse<IEnumerable<SizeResponse>>
                {
                    Data = sizes
                };
                if (!sizes.Any()) // Kontrollera om listan med produkter är tom
                {
                    response.Message = "No tags found in the database. 😱";
                }
                return Ok(response);
            }
            catch (Exception e)
            {
                return BadRequest("Error occurred during search and filter \U0001f937‍♀️: " + e.Message);
            }
        }
        [HttpGet("Type")]
        public async Task<ActionResult<ServiceResponse<IEnumerable<TypeResponse>>>> GetAllType()
        {
            try
            {
                var type = await _searchFilterService.GetAllTypeAsync();
                var response = new ServiceResponse<IEnumerable<TypeResponse>>
                {
                    Data = type
                };
                if (!type.Any()) // Kontrollera om listan med produkter är tom
                {
                    response.Message = "No tags found in the database. 😱";
                }
                return Ok(response);
            }
            catch (Exception e)
            {
                return BadRequest("Error occurred during search and filter \U0001f937‍♀️: " + e.Message);
            }
        }
        [HttpGet("Category")]
        public async Task<ActionResult<ServiceResponse<IEnumerable<CategoryResponse>>>> GetAllCategory()
        {
            try
            {
                var categories = await _searchFilterService.GetAllCategoryAsync();
                var response = new ServiceResponse<IEnumerable<CategoryResponse>>
                {
                    Data = categories
                };
                if (!categories.Any()) // Kontrollera om listan med produkter är tom
                {
                    response.Message = "No tags found in the database. 😱";
                }
                return Ok(response);
            }
            catch (Exception e)
            {
                return BadRequest("Error occurred during search and filter \U0001f937‍♀️: " + e.Message);
            }
        }
    }
}
