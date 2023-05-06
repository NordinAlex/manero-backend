using Manero_backend.DTOs.Order;
using Manero_backend.Models.OrderEntities;

namespace Manero_backend.Factories
{
    public static class OrderFactory
    {
        public static OrderEntity CreateOrderEntity() => new();
        public static OrderResponse CreateOrderResponse() => new();
    }
}
