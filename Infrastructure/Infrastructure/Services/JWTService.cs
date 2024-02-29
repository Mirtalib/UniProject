using Application.Models.Config;
using Application.Services;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Infrastructure.Services;

public class JWTService : IJWTService
{
    private readonly JWTConfig _config;

    public JWTService(JWTConfig config)
    {
        _config = config;
    }
    public string GenerateToken(string id, string email, IEnumerable<string> roles, IEnumerable<Claim> userClaims)
    {
        var claims = new[]
           {
                new Claim(ClaimsIdentity.DefaultNameClaimType, email),
                new Claim("userId", id),
                new Claim(ClaimsIdentity.DefaultRoleClaimType, string.Join(",", roles))
            }.Concat(userClaims);

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config.Secret));

        var signingCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            issuer: _config.Issuer,
            audience: _config.Audience,
            expires: DateTime.UtcNow.AddMinutes(_config.ExpireMinutes),
            signingCredentials: signingCredentials,
            claims: claims
            );

        var accessToken = new JwtSecurityTokenHandler().WriteToken(token);

        return accessToken;
    }
}
