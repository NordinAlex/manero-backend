using Manero_backend.Models.OrderEntities;

namespace Manero_backend.Factories
{
    public static class OrderLineFactory
    {
        public static OrderLineEntity CreateOrderLineEntity(int orderId, int productId, decimal price, int quantity, string name, decimal unitPrice) => new() { OrderId = orderId, ProductItemId = productId, Price = price, Quantity = quantity, ProductName = name, UnitPrice = unitPrice};
    }
}
