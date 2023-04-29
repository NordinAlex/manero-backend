using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
using Manero_backend;
using Manero_backend.Models.ProductEntities;
using Manero_backend.Models.UserProductEntities;
using System.ComponentModel.DataAnnotations.Schema;

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
        public string BrandEntity { get; set; } = null!;

        public int WishlistEntityId { get; set; }
        public string? Wishlist { get; set; }

        public string? ImageAlt { get; set; }
        public string? ImageName { get; set; }
        [NotMapped]
        public string? ImageFile { get; set; }

        public ICollection<string>? Images { get; set; } 
        public ICollection<string>? ReviewEntity { get; set; } 
        public ICollection<string> Sizes { get; set; } = null!; 
        public ICollection<string> Tags { get; set; } = null!; 
        public ICollection<string> Colors { get; set; } = null!; 
        public ICollection<string> Type { get; set; } = null!;
    }
}
