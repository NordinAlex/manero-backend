using Manero_backend.Interfaces.Order;
using Manero_backend.Models.ProductItemEntities;
using Manero_backend.Models.UserEntities;

namespace Manero_backend.DTOs.Order
{
    public class OrderResponse : IOrder
    {
        public int OrderId { get; set; }
        public string UserId { get; set; } = null!;
        public DateTime OrderDate { get; set; }
        public int ShippingAddressId { get; set; }
        public decimal TotalPrice { get; set; }

    }
}
