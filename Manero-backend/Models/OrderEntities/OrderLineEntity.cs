using Manero_backend.Models.ProductEntities;
using Manero_backend.Models.ProductItemEntities;

namespace Manero_backend.Models.OrderEntities
{
    public class OrderLineEntity
    {
        public int OrderId { get; set; }
        public OrderEntity Order { get; set; } = null!;
        public int ProductId { get; set; }
        public ProductItemEntity ProductItem { get; set; } = null!;
        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }
}
