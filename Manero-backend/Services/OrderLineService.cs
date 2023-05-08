using Manero_backend.DTOs.Order;
using Manero_backend.Factories;
using Manero_backend.Interfaces.OrderLine;
using Manero_backend.Models.OrderEntities;
using Manero_backend.Repository;

namespace Manero_backend.Services
{
    public class OrderLineService : IOrderLineService
    {
        public IOrderLineRepository _orderLineRepo;

        public OrderLineService(IOrderLineRepository orderLineRepo)
        {
            _orderLineRepo = orderLineRepo;
        }

        public async Task<bool> CreateOrderLineAsync(OrderRequest orderRequest, OrderEntity orderEntity)
        {
            var orderLineEntity = OrderLineFactory.CreateOrderLineEntity();
            foreach(var product in orderRequest.ProductItems)
            {
                orderLineEntity.OrderId = orderEntity.Id;
                orderLineEntity.ProductItemId = product.ProductId;
                await _orderLineRepo.CreateAsync(orderLineEntity);
            }
            return true;
        }
    }
}
