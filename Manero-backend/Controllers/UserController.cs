using Manero_backend.DTOs.User;
using Manero_backend.Interfaces.Users.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

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
        //[Authorize]
        [HttpGet("all")]
        public async Task<IEnumerable<UserResponse>> GetAllAsync()
        {
            return await _userService.GetAllAsync();
        }
        //[Authorize]
        [HttpDelete]
        public async Task<IActionResult> DeleteAsync(string id)
        {
            return await _userService.DeleteAsync(id);
        }
        [Authorize]
        [HttpPut("update")]
        public async Task<IActionResult> UpdateAsync(UpdateUser updateUser)
        {
            var result = await _userService.UpdateAsync(updateUser, User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Email)!.Value);

            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest(updateUser);
        }
    }
}
