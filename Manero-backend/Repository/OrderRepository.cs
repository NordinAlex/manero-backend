using Manero_backend.Interfaces.Order;
using Manero_backend.Models.OrderEntities;

namespace Manero_backend.Repository
{
    public class OrderRepository : IOrderRepository
    {
        public Task CreateOrderAsync(OrderEntity orderEntity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteOrderAsync(OrderEntity orderEntity)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<OrderEntity>> GetAllOrdersAsync()
        {
            throw new NotImplementedException();
        }

        public Task<OrderEntity> GetOrderByIdAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
