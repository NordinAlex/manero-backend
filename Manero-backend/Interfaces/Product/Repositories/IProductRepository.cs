using Manero_backend.DTOs.Product;
using Manero_backend.Interfaces.Product.Repositories;
using Manero_backend.Migrations.Identity;
using Manero_backend.Models.ProductEntities;
using System.Linq.Expressions;

namespace Manero_backend.Interfaces.Product
{
    public interface IProductRepository 
    {
        Task<IEnumerable<ProductEntity>> GetAllAsync();
        Task<ProductEntity> GetByIdAsync(int id);
        Task<IEnumerable<ProductEntity>> GetByTypeIdAsync(int typeId);
        Task<ProductEntity> AddAsync(ProductEntity entity);
        Task UpdateAsync(ProductEntity entity);
        Task DeleteAsync(int id);
        Task<IEnumerable<ProductEntity>> GetBySearchAsync(Expression<Func<ProductEntity, bool>> predicate);
        Task<IEnumerable<ProductEntity>> SearchAndFilterAsync(SearchFilterRequest searchFilterRequest);
    }
}
