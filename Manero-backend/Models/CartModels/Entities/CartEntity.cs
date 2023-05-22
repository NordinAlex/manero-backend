using Manero_backend.Models.UserEntities;

namespace Manero_backend.Models.CartsEntity
{
    //Oscar // Belal // Julius
    public class CartEntity
    {

        public int Id { get; set; }
        //Se om det går att ta bort Guid
        public string Email { get; set; } = null!;
        public UserEntity User { get; set; }
        public ICollection<CartItemEntity>? Items { get; set; }
    }
}
