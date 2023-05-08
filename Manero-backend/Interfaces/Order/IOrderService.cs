using Manero_backend.DTOs.Order;

namespace Manero_backend.Interfaces.Order
{
    public interface IOrderService
    {
        Task<OrderResponse> CreateOrderAsync(OrderRequest orderRequest);
        Task<IEnumerable<OrderResponse>> GetAllOrdersAsync();
        Task<OrderResponse> GetOrderByIdAsync();
        Task<bool> DeleteOrderAsync(int id);

    }
}
