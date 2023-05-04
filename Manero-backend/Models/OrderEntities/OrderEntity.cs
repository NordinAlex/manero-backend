using Manero_backend.Interfaces.Order;
using Manero_backend.Models.UserEntities;

namespace Manero_backend.Models.OrderEntities
{
    public class OrderEntity : IOrder
    {
        public int Id { get; set; }
        public string UserId { get; set; } = null!;
        public DateTime OrderDate { get; set; }
        public int ShippingAddressId { get; set; }
        public decimal TotalPrice { get; set; }

    }
}
