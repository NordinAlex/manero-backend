using Manero_backend.Interfaces.Product.Models;

namespace Manero_backend.Models.ProductEntities
{
    public class TypeEntity : ITypeEntity
    {
        public int Id { get; set; }
        public string Type { get; set; } = null!;

        public ICollection<ProductTypeEntity> ProductTypes { get; set; } = null!; // type kan ha flera produkter

    }
}
