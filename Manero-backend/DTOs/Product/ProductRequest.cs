using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Manero_backend;
using Manero_backend.Models.ProductEntities;
using Manero_backend.Models.UserProductEntities;

namespace Manero_backend.DTOs.Product
{
    public class ProductRequest
    {
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

        public ICollection<int>? ImagesIds { get; set; }
        public ICollection<int>? ReviewEntityIds { get; set; }
        public ICollection<int> SizesIds { get; set; } = null!;
        public ICollection<int> TagsIds { get; set; } = null!;
        public ICollection<int> ColorsIds { get; set; } = null!;
        public ICollection<int> TypeIds { get; set; } = null!;
    }

}
