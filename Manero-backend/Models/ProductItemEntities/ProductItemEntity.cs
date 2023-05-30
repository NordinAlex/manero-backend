using Manero_backend.Interfaces.ProductItem;
using Manero_backend.Models.ProductEntities;
using System.ComponentModel.DataAnnotations;

namespace Manero_backend.Models.ProductItemEntities
{
    public class ProductItemEntity : IProductItem // den här klassen definerar modellen för en specifik produkt 
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int ProductId { get; set; }
        public ProductEntity Product { get; set; } = null!;
        public int SizeId { get; set; }
        public SizeEntity Size { get; set; } = null!;
        public int ColorId { get; set; }
        public ColorEntity Color { get; set; } = null!;
        public string SKU { get; set; } = null!;
        public int QuantityInStock { get; set; }
        public decimal Price { get; set; }
        public ICollection<ImagesEntity>? Images { get; set; } // en product kan ha flera bilder som t.ex. fram sida och bak sida 
    }
}
