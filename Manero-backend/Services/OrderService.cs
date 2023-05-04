using Manero_backend.DTOs.Order;
using Manero_backend.Interfaces.Product.Services;

namespace Manero_backend.Services
{
    public class OrderService : IOrderService
    {
        public Task<OrderResponse> CreateOrderAsync(OrderRequest orderRequest)
        {
            throw new NotImplementedException();
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
