using Manero_backend.Models.ProductEntities;

namespace Manero_backend.Models.UserProductEntities
{
    public class WishlistEntity
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;

        public int UserId { get; set; }        
        public ICollection<ProductEntity> Products { get; set; }= null!;
    }
}
