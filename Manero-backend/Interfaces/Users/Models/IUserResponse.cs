namespace Manero_backend.Interfaces.Users.Models
{
    public interface IUserResponse
    {
        public string Token { get; set; }
        public string StatusMessage { get; set; }
        public bool Error { get; set; }
    }
}
