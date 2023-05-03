using Manero_backend.Context;
using Manero_backend.DTOs.Product;
using Manero_backend.DTOs.User;
using Manero_backend.Models.UserEntities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;

namespace Manero_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserManager<UserEntity> _userManager;

        public UserController(UserManager<UserEntity> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            var entity = await _userManager.Users.SingleOrDefaultAsync();
            return Ok(entity);
        }

        [HttpPost]
        public async Task<IActionResult> Create(SignUpRequest signuprequest)
        {
            UserEntity userEntity = signuprequest;

            if (ModelState.IsValid)
            {
                var res = await _userManager.CreateAsync(userEntity);
                if (res.Succeeded)
                    return Created("", res);
            }
            return BadRequest();
        }
    }
}

