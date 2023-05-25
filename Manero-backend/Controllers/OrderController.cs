using Manero_backend.DTOs.Order;
using Manero_backend.Factories;
using Manero_backend.Interfaces.Order;
using Manero_backend.Interfaces.Users.Service;
using Manero_backend.Models.UserEntities;
using Manero_backend.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Manero_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;
        private readonly UserManager<UserEntity> _userManager;

        public OrderController(IOrderService orderService, UserManager<UserEntity> userManager)
        {
            _orderService = orderService;
            _userManager = userManager;
        }

        [HttpPost]
        public async Task<IActionResult> Create(OrderRequest orderRequest)
        {
            if (ModelState.IsValid)
            {
                var actualEntity = _userManager.Users.FirstOrDefault(x => x.Email == User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Email)!.Value);
                var testEntity = new UserEntity();
                OrderResponse res = await _orderService.CreateOrderAsync(orderRequest, testEntity!);
                return Created("", res);
            }
            return BadRequest();
        }
        [HttpGet("id")]
        public async Task<IActionResult> Read(int id)
        {

            var order = await _orderService.GetOrderByIdAsync(id);
            if(order != null)
            {
                return Ok(order);
            }
            return NotFound();
        }
        [HttpGet("orderid-userid")]
        public async Task<IActionResult> ReadByUser(int orderId)
        {
            var userEntity = _userManager.Users.FirstOrDefault(x => x.Email == User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Email)!.Value);
            var order = await _orderService.GetUserOrderByIdAsync(orderId, userEntity!.Id);
            if(order != null) 
            {
                return Ok(order);
            }
            return NotFound();
        }
        [HttpGet]
        public async Task <IActionResult> ReadAll()
        {
            var orders = await _orderService.GetAllOrdersAsync();
            if (orders != null)
                return Ok(orders);
            return BadRequest();
        }
        [HttpGet("userId")]
        public async Task<IActionResult> ReadAllByUser()
        {
            var userEntity = _userManager.Users.FirstOrDefault(x => x.Email == User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Email)!.Value);
            var orders = await _orderService.GetOrdersForUser(userEntity!.Id);
            if(orders != null)
            {
                return Ok(orders);
            }
            return BadRequest();
        }
        [HttpDelete("id")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _orderService.DeleteOrderAsync(id);
            if (result)
            {
                return StatusFactory<OkResult>.Create();
            }
            return StatusFactory<BadRequestResult>.Create();
        }
    }
}
