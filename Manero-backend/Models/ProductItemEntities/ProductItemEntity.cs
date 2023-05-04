using Manero_backend.Interfaces.ProductItem;
using Manero_backend.Models.ProductEntities;

namespace Manero_backend.Models.ProductItemEntities
{
    public class ProductItemEntity : IProductItem // den här klassen definerar modellen för en specifik produkt 
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public ProductEntity Product { get; set; } = null!;
        public int SizeId { get; set; }
        public SizeEntity Size { get; set; } = null!;
        public int ColorId { get; set; }
        public ColorEntity Color { get; set; } = null!;
        public string SKU { get; set; } = null!;
        public int QuantityInStock { get; set; }
        public decimal Price { get; set; }
    }
}
