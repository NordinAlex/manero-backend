using Manero_backend.DTOs.User;
using Manero_backend.Interfaces.Users.Service;
using Manero_backend.Models.UserEntities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Internal;

namespace Manero_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterController : ControllerBase
    {
        private readonly UserManager<UserEntity> _userManager;
        private readonly IRegisterService _registerService;

        public RegisterController(UserManager<UserEntity> userManager, IRegisterService registerService)
        {
            _userManager = userManager;
            _registerService = registerService;
        }

        [HttpPost]
        public async Task<IActionResult> Create(UserRequest userRequest)
        {
            if(ModelState.IsValid) {
                 var result = await _registerService.CreateUserAsync(userRequest);
                if(result != null)
                {
                    return Created("", result);
                }
            }
            return BadRequest(userRequest);
        }

      

    }
}
