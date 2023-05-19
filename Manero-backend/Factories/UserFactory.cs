using Manero_backend.DTOs.User;
using Manero_backend.Models.UserEntities;

namespace Manero_backend.Factories
{
    public static class UserFactory
    {
        public static UserEntity CreateUserEntity() => new();
        public static UserResponse CreateUserResponse() => new();
       // public static UserResponsError CreateUserResponsError() => new();
       /* public static UserResponse CreateUserResponse(string errorMsg,bool error, string token) => new()
        {
            Token = token,
            StatusMessage = errorMsg,
            Error=error
        };*/
        public static UserResponse CreateUserResponse(string errorMsg, UserRequest request) => new()
        {
            StatusMessage = errorMsg,
            Request = request,
            Error = true
        };
        public static UserResponse CreateUserResponse(string token) => new()
        {
            Token = token
        };
        public static UserResponse CreateUserResponse(string errorMsg, bool error) => new()
        {
            StatusMessage = errorMsg,
            Error = error
        };
    }
}
