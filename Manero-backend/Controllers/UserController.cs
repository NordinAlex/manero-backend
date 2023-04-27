using Manero_backend.Context;
using Manero_backend.DTOs.User;
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

        [HttpGet()]
        public async Task<IActionResult> GetAsync()
        {
            var user = await _identitycontext.Users.GetAsync(a => a.Name == name);

            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(SignUpResponse signup)
        {
            if (ModelState.IsValid)
            {
                SignUpResponse res = await _identitycontext.CreateAsync(signup);
                if (res != null)
                    return Created("", res);
                    return Created("", res);
            }
            return BadRequest();
        }
    }
}
