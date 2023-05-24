using Manero_backend.DTOs.Order;
using Manero_backend.Factories;
using Manero_backend.Interfaces.Order;
using Manero_backend.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Manero_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpPost]
        public async Task<IActionResult> Create(OrderRequest orderRequest)
        {
            OrderResponse res = await _orderService.CreateOrderAsync(orderRequest);
            return Created("", res);
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
        [HttpGet("id, userId")]
        public async Task<IActionResult> ReadByUser(int orderId, string userId)
        {
            var order = await _orderService.GetUserOrderByIdAsync(orderId, userId);
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
        public async Task<IActionResult> ReadAllByUser(string id)
        {
            var orders = await _orderService.GetOrdersForUser(id);
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
