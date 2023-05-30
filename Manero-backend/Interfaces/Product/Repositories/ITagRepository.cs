using Manero_backend.Models.ProductEntities;

namespace Manero_backend.Interfaces.Product.Repositories
{
    public interface ITagRepository
    {
        Task<IEnumerable<TagsEntity>> GetAllTagAsync();
        Task<IEnumerable<TagsEntity>> GetTagsForProduct(int productId);
    }
    
}
