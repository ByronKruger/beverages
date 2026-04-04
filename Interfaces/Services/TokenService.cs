using Coffeeg.Entities;
using Coffeeg.Exceptions;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Coffeeg.Interfaces.Services
{
    public class TokenService(IConfiguration config, UserManager<User> userManager) : ITokenService
    {
        public async Task<string> CreateToken(User user)
        {
            var tokenKey = config["JwtTokenSecret"] ?? throw new CoffeegMissingConfigurationException("Cannot find token key");
            if (tokenKey.Length < 64) throw new CoffeegInvalidaConfigurationException("Token key value needs to be >= 64 characters");
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(tokenKey));

            var adminUserUpdated = await userManager.FindByEmailAsync(user.Email);
            var rolesNow = await userManager.GetRolesAsync(adminUserUpdated);   // should work

            var claims = new List<Claim>
            {
                new(ClaimTypes.Email, user.UserName),
                new(ClaimTypes.NameIdentifier, user.Id),
            };

            claims.AddRange(rolesNow.Select(r => new Claim(ClaimTypes.Role, r)));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = creds
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}
