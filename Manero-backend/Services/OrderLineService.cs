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
            
            foreach(var product in orderRequest.ProductItems)
            {
                var orderLineEntity = OrderLineFactory.CreateOrderLineEntity(orderEntity.Id, product.Id, product.LinePrice, product.Quantity, product.Name!, product.Price);
                await _orderLineRepo.CreateAsync(orderLineEntity);
            }
            return true;
        }
    }
}
