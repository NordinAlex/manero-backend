using Manero_backend.DTOs.User;
using Manero_backend.Models.UserEntities;

namespace Manero_backend.Factories
{
    public static class UserFactory
    {
        public static UserEntity CreateUserEntity() => new();
        public static UserResponse CreateUserResponse() => new();
        public static UserResponsError CreateUserResponsError() => new();
        public static UserResponsError CreateUserResponsError(string Error, UserRequest req) => new()
        {
            ErrorMessage=Error,
            FirstName=req.FirstName,
            LastName=req.LastName,
            PhoneNumber=req.PhoneNumber ?? null!,
            Email=req.Email
        };
    }
}
