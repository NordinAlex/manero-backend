namespace Manero_backend.Interfaces.Users.Models
{
    public interface IUpdateUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
    }
}
