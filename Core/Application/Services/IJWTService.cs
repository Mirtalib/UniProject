using System.Security.Claims;

namespace Application.Services;

public interface IJWTService
{
    string GenerateToken(string id, string email, IEnumerable<string> roles, IEnumerable<Claim> userClaims);
}
