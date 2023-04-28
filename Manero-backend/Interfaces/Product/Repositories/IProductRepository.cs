using Manero_backend.Models.ProductEntities;

namespace Manero_backend.Interfaces.Product
{
    public interface IProductRepository
    {
        Task<IEnumerable<ProductEntity>> GetAllArticles();
        Task<ProductEntity> GetArticleById(int id);
        Task<IEnumerable<ProductEntity>> GetArticlesByGroupId(int groupId);
        Task AddArticle(ProductEntity product);
        Task UpdateArticle(ProductEntity product);
        Task DeleteArticle(int id);
    }
}
