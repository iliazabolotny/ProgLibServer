using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using ProgLib.Core.Abstractions;
using ProgLib.Core.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ProgLib.Infrastructure
{
    public class JwtProvider: IJwtProvider
    {
        private readonly JwtOptions _options;
        public JwtProvider(IOptions<JwtOptions> options)
        {
            _options = options.Value;
        }

        public string GenerateToken(User user)
        {
            Claim[] claims = [new("userId", user.Id.ToString()), new("email", user.Email)];

            var loginCredentials = new SigningCredentials(
                new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_options.SecretKey)),
                SecurityAlgorithms.HmacSha256
                );

            var token = new JwtSecurityToken(
                claims: claims,
                signingCredentials: loginCredentials,
                expires: DateTime.UtcNow.AddHours(_options.ExpiresSet)
                );
            var tokenValue = new JwtSecurityTokenHandler().WriteToken(token);

            return tokenValue;
        }
    }
}
