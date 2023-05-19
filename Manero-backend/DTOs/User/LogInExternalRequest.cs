namespace Manero_backend.DTOs.User
{
    public class LogInExternalRequest
    {
        public string Email { get; set; } = null!;
        public string Issuer { get; set; } = null!;

    }
}
