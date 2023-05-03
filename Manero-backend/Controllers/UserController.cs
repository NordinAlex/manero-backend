using Manero_backend.Context;
using Manero_backend.DTOs.Product;
using Manero_backend.DTOs.User;
using Manero_backend.Interfaces.Product.Services;
using Manero_backend.Models.UserEntities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Manero_backend.Controllers //Robin och Leo 
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserContext _userContext;

        public UserController(UserContext userContext)
        {
            _userContext = userContext;
        }




        // Robin och Leo
        [HttpPost]
        public async Task<ActionResult<UserResponse>> CreateUser([FromBody] UserRequest userRequest)
        {
            var user = await _userContext.CreateUserAsync(userRequest);
            return Ok(User);
        }
    }
}
