using Manero_backend.Interfaces.Order;
using Manero_backend.Models.ProductEntities;
using Manero_backend.Models.ProductItemEntities;

namespace Manero_backend.DTOs.Order
{
    public class OrderRequest : IOrderRequest
    {
        
        public string UserId { get; set; } = null!;
        public DateTime OrderDate { get; set; }
        public int ShippingAddressId { get; set; }
        public decimal TotalPrice { get; set; }
        public List<ProductItemEntity> ProductItems { get; set; } = null!;
    }
}
