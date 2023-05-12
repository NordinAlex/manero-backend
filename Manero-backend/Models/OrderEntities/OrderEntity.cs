using Manero_backend.BaseModels.Order;
using Manero_backend.DTOs.Order;
using Manero_backend.DTOs.ProductItem;
using Manero_backend.Factories;
using Manero_backend.Interfaces.Order;
using Manero_backend.Models.UserEntities;

namespace Manero_backend.Models.OrderEntities
{
    public class OrderEntity : OrderBase, IOrderWithAddressId
    {
        public int Id { get; set; }
        public string UserId { get; set; } = null!;
        public DateTime OrderDate { get; set; }
        public int ShippingAddressId { get; set; }
        public decimal TotalPrice { get; set; }
        public List<OrderLineEntity> OrderLines { get; set; } = null!;

        public static implicit operator OrderResponse(OrderEntity orderEntity)
        {
            var res = OrderFactory.CreateOrderResponse();
            res.Id = orderEntity.Id;
            res.UserId = orderEntity.UserId;
            res.OrderDate = orderEntity.OrderDate;
            res.TotalPrice = orderEntity.TotalPrice;
            res.ShippingAddressId = orderEntity.ShippingAddressId;

            return res;
            
        }
    }
}
