using Manero_backend.Models.UserEntities;
using Manero_backend.Models;
using Manero_backend.Models.OrderEntities;

namespace Manero_backend.Interfaces.Users.Models
{
    public interface IUserEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
      
    }
}
