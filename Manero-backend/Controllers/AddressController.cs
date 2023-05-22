using Manero_backend.DTOs.Address;
using Manero_backend.DTOs.User;
using Manero_backend.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Web.Helpers;

namespace Manero_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class AddressController : ControllerBase
    {
        private readonly AddressService _addressService;

        public AddressController(AddressService addressService)
        {
            _addressService = addressService;
        }

        //[HttpPost]
        //public async Task<IActionResult> CreateAsync(AddressRequest request)
        //{
            
        //    var respons = await _addressService.CreateAddressAsync(request);
        //    if(respons != null)
        //    {
        //    }
        //    return BadRequest(respons);
        //    }            
        //}
        //[HttpGet]
        //public async Task<IActionResult> GetAllForOneUserAsync(string email)
        //{

        //    var respons = await _addressService.GetAllForOneUserAsync(email);

        //    return BadRequest(respons);

        //}
        //[HttpPut]
        //public async Task <IActionResult> RemoveAddressFromUser(AddressRequest request)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var respons = await _addressService.RemoveAddressFromUser(request);
        //        return BadRequest(respons);
        //    }
        //    return BadRequest(ModelState);
        //}

    }
}
