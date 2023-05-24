using Manero_backend.DTOs.Order;
using Manero_backend.Factories;
using Manero_backend.Interfaces.Addresses.Service;
using Manero_backend.Interfaces.Order;
using Manero_backend.Interfaces.OrderLine;
using Manero_backend.Models.UserEntities;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace Manero_backend.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepo;
        private readonly IOrderLineService _orderLineService;


        public OrderService(IOrderRepository orderRepo, IOrderLineService orderLineService)
        {
            _orderRepo = orderRepo;
            _orderLineService = orderLineService;

        }

        public async Task<OrderResponse> CreateOrderAsync(OrderRequest orderRequest) 
        {
            
            var entity = orderRequest;
            var addedOrderEntity = await _orderRepo.CreateOrderAsync(entity);
            await _orderLineService.CreateOrderLineAsync(orderRequest, addedOrderEntity);


            OrderResponse res = await _orderRepo.GetOrderByIdAsync(addedOrderEntity.Id);
            return res;
        }

        public async Task<bool> DeleteOrderAsync(int id)
        {
            var order = await _orderRepo.GetOrderByIdAsync(id);
            return await _orderRepo.DeleteOrderAsync(order);
            
        }

        public async Task<IEnumerable<OrderResponse>> GetAllOrdersAsync()
        {
            var orders = await _orderRepo.GetAllOrdersAsync();
            var resList = new List<OrderResponse>();
            foreach (var order in orders)
            {
                resList.Add(order);
            }
            return resList;
        }

        public async Task<OrderResponse> GetOrderByIdAsync(int id)
        {
            var entity = await _orderRepo.GetOrderByIdAsync(id);
            if (entity == null) return null!;
            OrderResponse res = entity;
            return res;
        }

        public async Task<IEnumerable<OrderResponse>> GetOrdersForUser(string id)
        {
            var orders = await _orderRepo.GetAllOrdersAsync();
            var userOrders = orders.Where(x => x.UserId == id);
            var resList = new List<OrderResponse>();
            foreach (var order in userOrders)
            {
                resList.Add(order);
            }
            return resList;
        }

        public async Task<OrderResponse> GetUserOrderByIdAsync(int orderId, string userId)
        {
            var orders = await GetOrdersForUser(userId);
            var order = orders.FirstOrDefault(x => x.Id == orderId);
            if (order == null) return null!;
            return order;
        }
    }
}
