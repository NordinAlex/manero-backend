namespace Manero_backend.Models.ProductEntities
{
    public class CategoryEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }= null!;
        public string? RouteUrl { get; set; }
    }
}
