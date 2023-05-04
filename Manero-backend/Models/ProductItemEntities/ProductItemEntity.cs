using Manero_backend.Interfaces.ProductItem;
using Manero_backend.Models.ProductEntities;

namespace Manero_backend.Models.ProductItemEntities
{
    public class ProductItemEntity : IProductItem
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public ProductEntity Product { get; set; } = null!;
        public string SKU { get; set; } = null!;
        public int QuantityInStock { get; set; }
        public decimal Price { get; set; }

    }
}
