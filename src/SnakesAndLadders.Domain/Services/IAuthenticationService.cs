using SnakesAndLadders.Domain.Models;
using System.Security.Claims;

namespace SnakesAndLadders.Domain.Services;

public interface IAuthenticationService
{
    public AuthenticationScheme GetAuthenticationScheme();

    public Task<bool> TryAuthenticateGuestAsync(string guestname, out ClaimsPrincipal guestPrincipal); 
}