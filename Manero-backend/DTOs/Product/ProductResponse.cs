using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
using Manero_backend;
using Manero_backend.Models.ProductEntities;
using Manero_backend.Models.UserProductEntities;

namespace Manero_backend.DTOs.Product
{
    public class ProductResponse
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public decimal Price { get; set; }
        public string Description { get; set; } = null!;
        public int Quantity { get; set; }
        public string SKU { get; set; } = null!;

        public int BrandEntityId { get; set; }
        public BrandEntity BrandEntity { get; set; } = null!;

        public int WishlistEntityId { get; set; }
        public WishlistEntity? Wishlist { get; set; }

        public ICollection<ImagesEntity>? Images { get; set; } 
        public ICollection<ReviewEntity>? ReviewEntity { get; set; } 
        public ICollection<ProductSizeEntity> Sizes { get; set; } = null!; 
        public ICollection<ProductTagsEntity> Tags { get; set; } = null!; 
        public ICollection<ProductColorEntity> Colors { get; set; } = null!; 
        public ICollection<ProductTypeEntity> Type { get; set; } = null!;
    }
}
