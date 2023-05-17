using Manero_backend.DTOs.Order;
using Manero_backend.Models.OrderEntities;

namespace Manero_backend.Interfaces.OrderLine
{
    public interface IOrderLineService
    {
        Task<bool> CreateOrderLineAsync(OrderRequest orderRequest, OrderEntity orderEntity);
    }
}
