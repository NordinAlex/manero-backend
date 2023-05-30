using Manero_backend.Models.ProductEntities;

namespace Manero_backend.Interfaces.Product.Models
{
    public interface ITagsEntity
    {
        int Id { get; set; }
        ICollection<ProductTagsEntity> ProductTags { get; set; }
        string Tag { get; set; }
    }
}