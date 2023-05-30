using Manero_backend.Interfaces.Product.Models;

namespace Manero_backend.Models.ProductEntities
{
    public class CategoryEntity : ICategoryEntity
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;

    }
}
