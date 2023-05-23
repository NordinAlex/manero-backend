using Manero_backend.DTOs.Address;
using Manero_backend.DTOs.User;
using Manero_backend.Interfaces.Addresses.Service;
using Manero_backend.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Web.Helpers;

namespace Manero_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AddressController : ControllerBase
    {
        private readonly IAddressService _addressService;

        public AddressController(IAddressService addressService)
        {
            _addressService = addressService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(AddressRequest request)
        {
            if(request.Email != User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Email)!.Value) { return BadRequest();}
            
            var respons = await _addressService.CreateAddressAsync(request);
            if (respons.Error == false)
            {
                return Ok(respons);
            }
            return BadRequest(respons);
        }

        [HttpGet("myaddresses")]
        public async Task<IActionResult> GetAllUserAddresses() 
        {
            var response = await _addressService.GetAllForOneUserAsync(User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Email)!.Value);
            if (!response.Error) { return Ok(response); }
            return BadRequest(response);
        }

        [HttpPut]
        public async Task<IActionResult> DeleteAsync(AddressRequest request)
        {
            request.Email = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Email)!.Value;

            var respons = await _addressService.InActivateAddressAsync(request);
            if (respons.Error == false)
            {
                return Ok(respons);
            }
            return BadRequest(respons);
        }
    }
}

