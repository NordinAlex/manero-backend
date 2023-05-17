using Manero_backend.DTOs.Product;
using Manero_backend.Models.ProductEntities;
using System.Linq.Expressions;

namespace Manero_backend.Interfaces.Product.Repositories
{
    public interface IRepository<TEntity>
    {
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<TEntity> GetByIdAsync(int id);
        Task<IEnumerable<TEntity>> GetByTypeIdAsync(int typeId);
        Task AddAsync(TEntity entity);
        Task UpdateAsync(TEntity entity);
        Task DeleteAsync(int id);
        Task<IEnumerable<TEntity>> GetBySearchAsync(Expression<Func<ProductEntity, bool>> predicate);
        Task<List<ProductEntity>> GetBySearchAndFilterAsync(SearchFilterCriteria criteria);
    }
}
