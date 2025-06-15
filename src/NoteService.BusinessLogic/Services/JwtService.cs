using Microsoft.Extensions.Options;
using NoteService.DataAccessLayer.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Security.Cryptography.Pkcs;

namespace NoteService.BusinessLogic.Services
{
    public class JwtService(IOptions<AuthSettings> options)
    {
        public string GenerateToken(User user)
        {
            string secretKey = options.Value.GetSecretKey();

            var claims = new List<Claim>()
            {
                new Claim("id", user.Id.ToString()),
                new Claim("username", user.Username),
            };
            var jwtToken = new JwtSecurityToken(
                expires: DateTime.UtcNow.Add(options.Value.Expires),
                claims: claims,
                signingCredentials: new SigningCredentials(
                        new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey)),
                        SecurityAlgorithms.HmacSha256
                    ),
                issuer: options.Value.Issuer,
                audience: options.Value.Audience);

            return new JwtSecurityTokenHandler().WriteToken(jwtToken);
        }
    }
}
