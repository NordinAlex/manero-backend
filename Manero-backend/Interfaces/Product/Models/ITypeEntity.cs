using Manero_backend.Models.ProductEntities;

namespace Manero_backend.Interfaces.Product.Models
{
    public interface ITypeEntity
    {
        int Id { get; set; }
        ICollection<ProductTypeEntity> ProductTypes { get; set; }
        string Type { get; set; }
    }
}