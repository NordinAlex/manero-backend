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
        public bool Featured { get; set; } = false;
        public string Name { get; set; } = null!;       
        public string Description { get; set; } = string.Empty;  
        public string Brand { get; set; } = null!;
        public string? Category { get; set; } 
        public ICollection<string> Tags { get; set; } = null!;      
        public ICollection<string> Type { get; set; } = null!;
        public ICollection<ProductItemResponse> Variants { get; set; } = new List<ProductItemResponse>();
    }
}
