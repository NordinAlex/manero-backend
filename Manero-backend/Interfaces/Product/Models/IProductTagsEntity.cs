using Manero_backend.Models.ProductEntities;

namespace Manero_backend.Interfaces.Product.Models
{
    public interface IProductTagsEntity
    {
        ProductEntity ProductEntity { get; set; }
        int ProductEntityId { get; set; }
        TagsEntity TagsEntity { get; set; }
        int TagsEntityId { get; set; }
    }
}