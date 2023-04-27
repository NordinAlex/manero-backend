using Manero_backend.DTOs.User;

namespace Manero_backend.Factories
{
    public class SignUpDtoFactory
    {
        public static SignUpResponse Create()
        {
            return new SignUpResponse();
        }
    }
}
