using SnakesAndLadders.Domain.Extensions;
using SnakesAndLadders.Domain.Models;
using System.Security.Claims;

namespace SnakesAndLadders.Domain.Extensions;

public static class GuestExtensions
{
    public static ClaimsPrincipal GetClaimsPrincipal(this Guest guest, string authenticationScheme)
    {
        var claims = new List<Claim>() 
        {
            new Claim(nameof(AuthenticationClaim.Username), guest.Username),
            new Claim(nameof(AuthenticationClaim.UserId), guest.Id.ToString()),
            new Claim(nameof(AuthenticationClaim.UserRole), "Guest"),
        };
        var claimsIdentity = new ClaimsIdentity(claims, authenticationScheme);
        return new ClaimsPrincipal(claimsIdentity);
    }
}