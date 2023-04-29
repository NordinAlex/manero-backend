using Manero_backend.Context;
using Manero_backend.Interfaces.Product;
using Manero_backend.Models.ProductEntities;

namespace Manero_backend.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly DataContext _context;
        public ProductRepository(DataContext context)
        {
            _context = context;
        }

        public Task AddProductAsync(ProductEntity product)
        {
            throw new NotImplementedException();
        }

        public Task DeleteProductAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ProductEntity>> GetAllProductAsync()
        {
            throw new NotImplementedException();
        }

        public Task<ProductEntity> GetProductByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ProductEntity>> GetProductByTypeIdAsync(int TypeId)
        {
            throw new NotImplementedException();
        }

        public Task UpdateProductAsync(ProductEntity product)
        {
            throw new NotImplementedException();
        }
    }
}
