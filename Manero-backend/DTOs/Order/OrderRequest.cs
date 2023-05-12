using Manero_backend.DTOs.ProductItem;
using Manero_backend.Factories;
using Manero_backend.Interfaces.Order;
using Manero_backend.Models.OrderEntities;
using Manero_backend.Models.ProductEntities;
using Manero_backend.Models.ProductItemEntities;

namespace Manero_backend.DTOs.Order
{
    public class OrderRequest : IOrderRequest
    {
        
        public string UserId { get; set; } = null!;
        public DateTime OrderDate { get; set; }
        public int ShippingAddressId { get; set; }
        public List<ProductItemOrderRequestModel> ProductItems { get; set; } = null!;

        public static implicit operator OrderEntity(OrderRequest orderRequest)
        {
            var orderEntity = OrderFactory.CreateOrderEntity();
            orderEntity.UserId = orderRequest.UserId;
            orderEntity.OrderDate = orderRequest.OrderDate = DateTime.Now;
            orderEntity.ShippingAddressId = orderRequest.ShippingAddressId;
            foreach(var item in orderRequest.ProductItems) 
            {
                orderEntity.TotalPrice += item.Price * item.Quantity;
            }
            
            return orderEntity;
        }
    }
}
