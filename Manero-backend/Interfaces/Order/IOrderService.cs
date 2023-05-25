using Manero_backend.DTOs.Order;
using Manero_backend.Models.UserEntities;

namespace Manero_backend.Interfaces.Order
{
    public interface IOrderService
    {
        Task<OrderResponse> CreateOrderAsync(OrderRequest orderRequest, UserEntity user);
        Task<IEnumerable<OrderResponse>> GetAllOrdersAsync();
        Task<OrderResponse> GetOrderByIdAsync(int id);
        Task<bool> DeleteOrderAsync(int id);
        Task<IEnumerable<OrderResponse>> GetOrdersForUser(string id);
        Task<OrderResponse> GetUserOrderByIdAsync(int orderId, string userId);

    }
}
