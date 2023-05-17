using Manero_backend.Models.ProductEntities;

namespace Manero_backend.Interfaces.Product.Repositories
{
    public interface ITypeRepository
    {
        Task<IEnumerable<TypeEntity>> GetAllTypeAsync();
    }
}
