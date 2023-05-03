namespace Manero_backend.DTOs.User
{
    public class AddAddressRequest
    {
        public string Title { get; set; } = null!;
        public string Address { get; set; } = null!;
        public bool UseCurrent { get; set; } = false!;
    }
}
