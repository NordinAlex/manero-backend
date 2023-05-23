using Manero_backend.BaseModels.Order;
using Manero_backend.DTOs.Order;
using Manero_backend.DTOs.ProductItem;
using Manero_backend.Factories;
using Manero_backend.Interfaces.Order;
using Manero_backend.Models.UserEntities;

namespace Manero_backend.Models.OrderEntities
{
    public class OrderEntity : OrderBase
    {
        public List<OrderLineEntity> OrderLines { get; set; } = null!;

        public static implicit operator OrderResponse(OrderEntity orderEntity)
        {
            var res = OrderFactory.CreateOrderResponse();
            res.Id = orderEntity.Id;
            res.UserId = orderEntity.UserId;
            res.CustomerName = orderEntity.CustomerName;
            res.OrderDate = orderEntity.OrderDate;
            res.TotalPrice = orderEntity.TotalPrice;
            res.Address = orderEntity.Address;
            res.City = orderEntity.City;
            res.PostalCode = orderEntity.PostalCode;
            res.ProductItems = orderEntity.OrderLines.Select(x =>
            {
                var prores = ProductItemFactory.CreateProductItemModel();
                prores.Name = x.ProductName;
                prores.Id = x.ProductItemId;
                prores.Price = x.UnitPrice;
                prores.Quantity = x.Quantity;

                return prores;
            }).ToList();
            
            return res;
            
        }
    }
}
