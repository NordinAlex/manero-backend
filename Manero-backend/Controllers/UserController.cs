using Manero_backend.Interfaces.Users.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Manero_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync(string id)
        {
            var respons = await _userService.GetAsync(id);
            if (respons != null)
            {
                return Ok(respons);
            }
            return BadRequest("Invalid ID");
        }
    }
}
