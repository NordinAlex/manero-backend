using Manero_backend.DTOs.Product;
using Manero_backend.Models.ProductItemEntities;
using Manero_backend.Models.UserProductEntities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Manero_backend.Models.ProductEntities
{
    public class ProductEntity
    {      
        public int Id { get; set; }
        public string Name { get; set; } = null!;        
        public string Description { get; set; } = null!;  
        public int BrandEntityId { get; set; }
        public int CategoryEntityId { get; set; }
        public CategoryEntity? Category { get; set; }
        
        public bool Featured { get; set; } = false;
        public BrandEntity BrandEntity { get; set; } = null!; // en product kan ha en brand
        public ICollection<ReviewEntity>? ReviewEntity { get; set; } // en product kan ha flera reviews      
        public ICollection<ProductTagsEntity> Tags { get; set; } = null!; // en product kan ha flera tags som t.ex. tröja och sport   
        public ICollection<ProductTypeEntity> Type { get; set; } = null!; // en product kan ha flera typer som t.ex. NEW, SALE och TOP
        public ICollection<ProductItemEntity> Variants { get; set; } = null!; // en product kan ha flera varianter        
    }
}
