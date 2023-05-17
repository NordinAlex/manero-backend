using Manero_backend.DTOs.Order;
using Manero_backend.Models.OrderEntities;

namespace Manero_backend.Interfaces.Order
{
    public interface IOrderRepository
    {
       Task<OrderEntity> CreateOrderAsync(OrderEntity orderEntity);
       Task<IEnumerable<OrderEntity>> GetAllOrdersAsync();
       Task<bool> DeleteOrderAsync(OrderEntity orderEntity);
       Task<OrderEntity> GetOrderByIdAsync(int id);
       
    }
}
