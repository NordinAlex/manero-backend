using Microsoft.EntityFrameworkCore;

namespace Manero_backend.Models.UserEntities
{
    [PrimaryKey(nameof(UserId), nameof(CompanyId))]
    public class UserCompanyEntity
    {
        public string UserId { get; set; } = null!;
        public UserEntity User { get; set; } = null!;


        public int CompanyId { get; set; }
        public CompanyEntity Company { get; set; } = null!;
    }
}
