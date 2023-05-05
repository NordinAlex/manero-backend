using Manero_backend.DTOs.User;
using Manero_backend.Factories;
using Manero_backend.Interfaces.Users.Models;
using Manero_backend.Models.OrderEntities;
using Microsoft.AspNetCore.Identity;

namespace Manero_backend.Models.UserEntities
{
    public class UserEntity : IdentityUser, IUserEntity
    {
        public UserEntity()
        {
            this.Addresses = new HashSet<AddressEntity>();
        }

        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public virtual ICollection<AddressEntity> Addresses { get; set; } 
        public virtual ICollection<OrderEntity> Orders { get; set; }

        public static implicit operator UserResponse(UserEntity entity)
        {
            if(entity != null)
            {
                var result = UserFactory.CreateUserResponse();

                result.FirstName = entity.FirstName;
                result.LastName = entity.LastName;
                result.PhoneNumber = entity.PhoneNumber;
                result.Email = entity.Email;

                return result;
            }
            return null!;
        }

    }
}
