using Manero_backend.Models.ProductEntities;

namespace Manero_backend.Interfaces.ProductItem
{
    public interface IProductItem
    {
        public int ProductId { get; set; }
        public ProductEntity Product { get; set; }
        public string SKU { get; set; }
        public int QuantityInStock { get; set; }
        public decimal Price { get; set; }
    }
}
