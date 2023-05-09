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
        public string Description { get; set; } = string.Empty;  
        public string Brand { get; set; } = null!;
        public ICollection<string> Tags { get; set; } = null!;      
        public ICollection<string> Type { get; set; } = null!;
    }
    public class ProductItemResponse  // Product Variation
    {
        public string Color { get; set; } = null!;
        public string Size { get; set; } = null!;
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public int SizesIds { get; set; }
        public int ColorsIds { get; set; }
        public ICollection<string>? ImageAlt { get; set; }
        public ICollection<string>? ImageName { get; set; }       
    }
}
