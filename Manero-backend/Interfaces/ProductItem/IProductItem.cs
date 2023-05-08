using Manero_backend.Models.ProductEntities;

namespace Manero_backend.Interfaces.ProductItem
{
    public interface IProductItem
    {
        public int ProductId { get; set; }
        public ProductEntity Product { get; set; }
        public int SizeId { get; set; }
        public SizeEntity Size { get; set; }
        public int ColorId { get; set; }
        public ColorEntity Color { get; set; }
        public string SKU { get; set; }
        public int QuantityInStock { get; set; }
        public decimal Price { get; set; }
        public ICollection<ImagesEntity>? Images { get; set; }
    }
}
