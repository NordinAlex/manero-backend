using Manero_backend.DTOs.Product;

namespace Manero_backend.Interfaces.Product.Models
{
    public interface IProductRequest
    {
        int BrandId { get; set; }
        int CategoryId { get; set; }
        string Description { get; set; }
        bool Featured { get; set; }
        string Name { get; set; }
        int SeasonNumber { get; set; }
        ICollection<int> TagsId { get; set; }
        ICollection<int> TypeId { get; set; }
        ICollection<ProductItemRequest> Variants { get; set; }
    }
}