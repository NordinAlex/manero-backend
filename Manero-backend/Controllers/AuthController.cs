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

        [HttpPost]
        public async Task<IActionResult> Create(UserRequest userRequest)
        {
            if(ModelState.IsValid) {
                //var checkemail = await _registerService.CheckEmailAsync(userRequest.Email);
                if (await _authService.CheckEmailAsync(userRequest.Email))
                {
                    return Conflict(UserFactory.CreateUserResponse("Email already exist",true,userRequest));
                }
                var result = await _authService.CreateUserAsync(userRequest);
                if(result != null)
                {
                    if(!result.Error)
                    return Created("", result);
                }
                return BadRequest(result);
            } 
            return BadRequest(ModelState);
        }
        [HttpPost("login")]
        public async Task<IActionResult> LoginAsync(LogInReq loginReq)
        {

            if(ModelState.IsValid) 
            {
                if (await _authService.CheckEmailAsync(loginReq.Email))
                { var result = await _authService.LogInAsync(loginReq);
                    return Ok(result);
                }
            }
            return BadRequest();
        }
        
    }
}
