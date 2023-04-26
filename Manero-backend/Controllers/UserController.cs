using Manero_backend.Context;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Manero_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IdentityContext _identityContext;

        public UserController(IdentityContext identityContext)
        {
            _identityContext = identityContext;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(string id)
        {
            if (!Guid.TryParse(id, out var guid))
            {
                return BadRequest("Bruh please write a guid");
            }

            var article = await _identityContext.GetAsync(a => a.Id == id);

            if (article == null)
            {
                return NotFound();
            }

            return Ok(article);
        }

        [HttpPost]
        public async Task<IActionResult> Create(SignUpDto signup)
        {
            if (ModelState.IsValid)
            {
                ArticleResponse res = await _articleRepository.CreateAsync(article);
                if (res != null)
                    return Created("", res);
            }
            return BadRequest();
        }
    }
}
