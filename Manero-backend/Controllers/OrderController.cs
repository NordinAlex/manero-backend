using Manero_backend.DTOs.Order;
using Manero_backend.Factories;
using Manero_backend.Interfaces.Order;
using Manero_backend.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Manero_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
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
        public async Task<OrderResponse> Read(int id)
        {
            return await _orderService.GetOrderByIdAsync(id);
        }
        [HttpGet]
        public async Task<IEnumerable<OrderResponse>> ReadAll()
        {
            return await _orderService.GetAllOrdersAsync();
        }
        [HttpGet("userId")]
        public async Task<IEnumerable<OrderResponse>> ReadAllByUser(string id)
        {
            return await _orderService.GetOrdersForUser(id);
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
