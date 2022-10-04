using SnakesAndLadders.Domain.Extensions;
using SnakesAndLadders.Domain.Models;
using System.Security.Claims;

namespace SnakesAndLadders.Domain.Extensions;

public static class GuestExtensions
{
    public static ClaimsPrincipal GetClaimsPrincipal(this Guest guest, AuthenticationScheme authenticationScheme)
    {
        var claims = new List<Claim>() 
        { 
            new Claim(nameof(AuthenticationClaim.UserId), guest.Username),
            new Claim(nameof(AuthenticationClaim.Username), guest.Id.ToString()),
            new Claim(nameof(AuthenticationClaim.UserRole), "Guest"),
        };
        var claimsIdentity = new ClaimsIdentity(claims, authenticationScheme.Name());
        return new ClaimsPrincipal(claimsIdentity);
    }
}