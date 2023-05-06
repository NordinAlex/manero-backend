using Manero_backend.Models.OrderEntities;

namespace Manero_backend.Factories
{
    public static class OrderLineFactory
    {
        public static OrderLineEntity CreateOrderLineEntity() => new();
    }
}
