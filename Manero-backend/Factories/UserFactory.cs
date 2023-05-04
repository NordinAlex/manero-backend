using Manero_backend.DTOs.User;
using Manero_backend.Models.UserEntities;

namespace Manero_backend.Factories
{
    public static class UserFactory
    {
        public static UserEntity CreateUserEntity() => new ();

        public static UserResponse CreateUserResponse() => new();
    }
}
