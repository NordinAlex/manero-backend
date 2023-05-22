using Manero_backend.DTOs.User;
using Manero_backend.Factories;
using Manero_backend.Interfaces.Users.Models;
using Manero_backend.Interfaces.Users.Service;
using Manero_backend.Models.UserEntities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.IdentityModel.Tokens;

namespace Manero_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<UserEntity> _userManager;
        private readonly IAuthService _authService;


        public AuthController(UserManager<UserEntity> userManager, IAuthService authService)
        {
            _userManager = userManager;
            _authService = authService;
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateAsync(UserRequest userRequest)
        {
            if(ModelState.IsValid) {

                if (await _authService.CheckEmailAsync(userRequest.Email))
                {
                    return Conflict(UserFactory.CreateUserResponse("Email already exist", userRequest));
                }
                var result = await _authService.CreateUserAsync(userRequest);
                if (result.Error)
                {
                    return BadRequest(UserFactory.CreateUserResponse("Could not create an account", userRequest));
                }
                return Created("", result);
            } 
            return BadRequest(ModelState);
        }
        [HttpPost("login")]
        public async Task<IActionResult> LoginAsync(LogInReq loginReq)
        {

            if (true) 
            {
                if (!await _authService.CheckEmailAsync(loginReq.Email))
                { return BadRequest(UserFactory.CreateUserResponse("Wrong email or password!", true)); }
                { var result = await _authService.LogInAsync(loginReq);
                    if (!result.Error)
                        return Ok(result);
                    else
                        return BadRequest(result);
                }
            }
            return BadRequest();
        }
        [HttpPost("create/external")]
        public async Task<IActionResult> CreateExternalAsync(UserRequest userRequest)
        {
            if(ModelState.IsValid)
            {
            var result = await _authService.CreateSocialAsync(userRequest);

            if (!result.Error)
            {
                return Ok(result);
            }
            return BadRequest(result);
            }
            return BadRequest(ModelState);
        }
        [HttpPost("login/external")]
        public async Task<IActionResult> LoginAsyncExternalAsync(LogInExternalRequest request)
        {
            if (!request.CreatedBy.IsNullOrEmpty())
            {
                var result = await _authService.LogInExternalAsync(request);
                if (!result.Error)
                    return Ok(result);
                return BadRequest(result);
            }
            return BadRequest(UserFactory.CreateUserResponse("Can't login", true));
        }


    }
}
