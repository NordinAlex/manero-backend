using Manero_backend.DTOs.Product;

namespace Manero_backend.Interfaces.Product.Models
{
    public interface IProductResponse
    {
        string Brand { get; set; }
        string? Category { get; set; }
        string Description { get; set; }
        bool Featured { get; set; }
        int Id { get; set; }
        string Name { get; set; }
        ICollection<string> Tags { get; set; }
        ICollection<string> Type { get; set; }
        ICollection<ProductItemResponse> Variants { get; set; }
    }
}