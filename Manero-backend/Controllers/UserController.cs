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
            if (!Guid.TryParse(id, out var guid))
            {
                return BadRequest("Error!");
            }

            var user = await _identitycontext.Users.SingleOrDefaultAsync();

            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(SignUpResponse signup)
        {
            /*
            if (ModelState.IsValid)
            {
                SignUpResponse res = await _identitycontext.CreateAsync(signup);
                if (res != null)
                    return Created("", res);
                return Created("", res);
            */
            return BadRequest();
        }
    }
}

