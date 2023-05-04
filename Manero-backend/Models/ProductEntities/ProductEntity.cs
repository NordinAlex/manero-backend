using Manero_backend.DTOs.Product;
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

        // denna kan behövas ta bort då det förmodligen är bättre att ha SKU i productItem istället då det är där vi definerar storlek färg osv
        public string SKU { get; set; } = null!; 


        // Hur många av varje storlek som finns i lager
        public int QuantityXS { get; set; } = 0;
        public int QuantityS { get; set; } = 0;
        public int QuantityM { get; set; } = 0;
        public int QuantityL { get; set; } = 0;
        public int QuantityXL { get; set; } = 0;
        public int QuantityXXL { get; set; } = 0;
        public int QuantityOneSize { get; set; } = 0;

        public int BrandEntityId { get; set; }      
        public BrandEntity BrandEntity { get; set; } = null!; // en product kan ha en brand

        //public int WishlistEntityId { get; set; }
        public WishlistEntity? Wishlist { get; set; } // en product kan ha en wishlist

        public ICollection<ImagesEntity>? Images { get; set; } // en product kan ha flera bilder
        public ICollection<ReviewEntity>? ReviewEntity { get; set; } // en product kan ha flera reviews
        public ICollection<ProductSizeEntity> Sizes { get; set; } = null!; // en product kan ha flera storlekar
        public ICollection<ProductTagsEntity> Tags { get; set; } = null!; // en product kan ha flera tags
        public ICollection<ProductColorEntity> Colors { get; set; } = null!; // en product kan ha flera färger
        public ICollection<ProductTypeEntity> Type { get; set; } = null!; // en product kan ha flera typer

      
    }
}
