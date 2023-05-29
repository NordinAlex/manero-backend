namespace Manero_backend.Interfaces.Product.Models
{
    public interface IBrandEntity
    {
        string? BrandCode { get; set; }
        string BrandName { get; set; }
        int Id { get; set; }
    }
}