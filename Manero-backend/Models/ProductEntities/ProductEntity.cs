using Manero_backend.Models.UserProductEntities;
using System.ComponentModel.DataAnnotations.Schema;

namespace Manero_backend.Models.ProductEntities
{
    public class ProductEntity
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public decimal Price { get; set; }
        public string Description { get; set; } = null!;
        public int Quantity { get; set; }
        public string SKU { get; set; } = null!;

        public int BrandEntityId { get; set; }      
        public BrandEntity BrandEntity { get; set; } = null!; // en product kan ha en brand

        public int WishlistEntityId { get; set; }
        public WishlistEntity? Wishlist { get; set; } // en product kan ha en wishlist

        public ICollection<ImagesEntity>? Images { get; set; } // en product kan ha flera bilder
        public ICollection<ReviewEntity>? ReviewEntity { get; set; } // en product kan ha flera reviews
        public ICollection<ProductSizeEntity> Sizes { get; set; } = null!; // en product kan ha flera storlekar
        public ICollection<ProductTagsEntity> Tags { get; set; } = null!; // en product kan ha flera tags
        public ICollection<ProductColorEntity> Colors { get; set; } = null!; // en product kan ha flera färger
        public ICollection<ProductTypeEntity> Type { get; set; } = null!; // en product kan ha flera typer
    }
}
