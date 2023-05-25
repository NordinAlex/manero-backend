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
        
        public DateTime OrderDate { get; set; }
        public List<ProductItemOrderModel> ProductItems { get; set; } = null!;
        public string Address { get; set; } = null!;
        public string City { get; set; } = null!;
        public string PostalCode { get; set; } = null!;

        public static implicit operator OrderEntity(OrderRequest orderRequest)
        {
            var orderEntity = OrderFactory.CreateOrderEntity();
            orderEntity.OrderDate = orderRequest.OrderDate = DateTime.Now;
            orderEntity.Address = orderRequest.Address;
            orderEntity.City = orderRequest.City;
            orderEntity.PostalCode = orderRequest.PostalCode;
            foreach(var item in orderRequest.ProductItems) 
            {
                orderEntity.TotalPrice += item.Price * item.Quantity;
            }
            
            return orderEntity;
        }
    }
}
