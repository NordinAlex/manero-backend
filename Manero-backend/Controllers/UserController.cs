using Manero_backend.Context;
using Manero_backend.DTOs.User;
using Manero_backend.Models.UserEntities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Manero_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IdentityContext _identitycontext;
  


        public UserController(IdentityContext identitycontext)
        {
            _identitycontext = identitycontext;

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(string id)
        {
            var article = await _identitycontext.GetAsync(a => a.Id == id);

            if (article == null)
            {
                return NotFound();
            }

            return Ok(article);
        }

        [HttpPost]
        public async Task<IActionResult> Create(SignUpRequest user)
        {
            if (ModelState.IsValid)
            {
                SignUpResponse res = await _identitycontext.CreateAsync(user);
                if (res != null)
                    return Created("", res);
            }
            return BadRequest();
        }
    }
}

