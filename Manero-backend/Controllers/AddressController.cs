using Manero_backend.DTOs.Address;
using Manero_backend.DTOs.User;
using Manero_backend.Factories;
using Manero_backend.Interfaces.Addresses.Service;
using Manero_backend.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
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
            try
            {
            request.Email = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Email)!.Value;
            } catch (Exception ex) { Debug.WriteLine(ex); }
            
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
            try
            {
                var response = await _addressService.GetAllForOneUserAsync(User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Email)!.Value);
                if (!response.Error) { return Ok(response); }
                return BadRequest(response);
            }
            catch (Exception ex) { Debug.WriteLine(ex); }
            return BadRequest(AddressFactory.CreateResponse("Something went wrong", true));
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

