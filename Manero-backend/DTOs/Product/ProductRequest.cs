using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Manero_backend;
using Manero_backend.Models.ProductEntities;
using Manero_backend.Models.UserProductEntities;

namespace Manero_backend.DTOs.Product
{
    public class ProductRequest // Product (product grupp) Request  
    {
        public string Name { get; set; } = null!;        
        public string Description { get; set; } = null!;  
        public int BrandId { get; set; } 
        public ICollection<int> TagsIds { get; set; } = null!;
        public ICollection<int> TypeIds { get; set; } = null!;
    }
       
    public class ProductItemRequest  // Product Variation Request
    {
        public string Color { get; set; } = null!;
        public string Size { get; set; } = null!;
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public int SizesIds { get; set; }
        public int ColorsIds { get; set; }

        public ICollection<string>? ImageAlt { get; set; }
        public ICollection<string>? ImageName { get; set; }
        public ICollection<IFormFile>? ImageFile { get; set; }
    }
}
