using Manero_backend.DTOs.Order;
using Manero_backend.Factories;
using Manero_backend.Interfaces.Order;
using Manero_backend.Interfaces.OrderLine;

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
            var entity = OrderFactory.CreateOrderEntity();
            entity.OrderDate = orderRequest.OrderDate = DateTime.Now;
            entity.UserId = orderRequest.UserId;
            entity.ShippingAddressId = orderRequest.ShippingAddressId;
            entity.TotalPrice = orderRequest.TotalPrice;
            var addedOrderEntity = await _orderRepo.CreateOrderAsync(entity);
            await _orderLineService.CreateOrderLineAsync(orderRequest, addedOrderEntity);
            

            var res = OrderFactory.CreateOrderResponse();
            return res;
        }

        public Task<bool> DeleteOrderAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<OrderResponse>> GetAllOrdersAsync()
        {
            throw new NotImplementedException();
        }

        public Task<OrderResponse> GetOrderByIdAsync()
        {
            throw new NotImplementedException();
        }
    }
}
