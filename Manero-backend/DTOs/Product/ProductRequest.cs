using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Manero_backend;
using Manero_backend.Models.ProductEntities;
using Manero_backend.Models.UserProductEntities;

namespace Manero_backend.DTOs.Product
{
    public class ProductRequest // Product (product grupp) Request  
    {
        public string Name { get; set; } = null!;
        public bool Featured { get; set; } = false;
        public string Description { get; set; } = null!;
        public int SeasonNumber { get; set; }
        public int BrandId { get; set; }  
        public int CategoryId { get; set; }
        public ICollection<int> TagsId { get; set; } = null!;
        public ICollection<int> TypeId { get; set; } = null!;
        public ICollection<ProductItemRequest> Variants { get; set; } = new List<ProductItemRequest>();

    }
}
