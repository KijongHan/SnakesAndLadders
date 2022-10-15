using SnakesAndLadders.Domain.Models;
using System.Security.Claims;

namespace SnakesAndLadders.Domain.Services;

public interface IUserAuthenticationService
{
    public JwtToken GenerateJwtToken(ClaimsPrincipal claimsPrincipal);

    public Task<ClaimsPrincipal?> TryAuthenticateGuestAsync(string guestname, string authenticationScheme); 
}