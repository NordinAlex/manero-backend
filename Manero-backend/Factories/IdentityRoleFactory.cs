using Microsoft.AspNetCore.Identity;

namespace Manero_backend.Factories
{
    public static class IdentityRoleFactory
    {
        public static IdentityRole CreateRole(string role) => new IdentityRole(role);
    }
}
