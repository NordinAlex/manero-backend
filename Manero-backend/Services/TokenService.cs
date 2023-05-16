using Manero_backend.Models.UserEntities;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Manero_backend.Services
{
    public class TokenService
    {
        private readonly IConfiguration _configuration;
        public TokenService(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        //Async await ? (PB)
        public string CreateToken(UserEntity entity, string role) 
        {
            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.GivenName, entity.FirstName!),
                new Claim(ClaimTypes.Surname, entity.LastName!),
                new Claim(ClaimTypes.Email, entity.Email!),
                new Claim(ClaimTypes.Role, role),
                new Claim("DisplayName", $"{entity.FirstName} {entity.LastName}")
            };
            var tokenHandler = new JwtSecurityTokenHandler();
            var securityTokenDescriptor = new SecurityTokenDescriptor
            {
                Issuer = _configuration["TokenService:Issuer"],
                Audience = _configuration["TokenService:Audience"],
                Expires = DateTime.Now.AddHours(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey
                (Encoding.UTF8.GetBytes(_configuration["TokenService:Secret"]!)), SecurityAlgorithms.HmacSha512Signature),
                Subject = new ClaimsIdentity(claims)
            };
            return tokenHandler.WriteToken(tokenHandler.CreateToken(securityTokenDescriptor));
        }
    }
}
