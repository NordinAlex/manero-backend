using Manero_backend.Models.ProductEntities;
using Manero_backend.Models.ProductItemEntities;
using Manero_backend.Models.UserProductEntities;

namespace Manero_backend.Interfaces.Product.Models
{
    public interface IProductEntity
    {
        BrandEntity BrandEntity { get; set; }
        int BrandEntityId { get; set; }
        CategoryEntity? Category { get; set; }
        int CategoryEntityId { get; set; }
        string Description { get; set; }
        bool Featured { get; set; }
        int Id { get; set; }
        string Name { get; set; }
        ICollection<ReviewEntity>? ReviewEntity { get; set; }
        ICollection<ProductTagsEntity> Tags { get; set; }
        ICollection<ProductTypeEntity> Type { get; set; }
        ICollection<ProductItemEntity> Variants { get; set; }
    }
}