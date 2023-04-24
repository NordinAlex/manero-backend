namespace Manero_backend.Models.UserEntities
{
    public class CompanyEntity
    {
        public int Id { get; set; }
        public string CompanyName { get; set; } = null!;

        public ICollection<UserCompanyEntity> UserCompanies { get; set; } = new HashSet<UserCompanyEntity>();
    }
}
