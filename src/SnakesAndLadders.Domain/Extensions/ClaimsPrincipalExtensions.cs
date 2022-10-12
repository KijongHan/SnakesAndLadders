using SnakesAndLadders.Domain.Models;
using System.Diagnostics;
using System.Security.Claims;

namespace SnakesAndLadders.Domain.Extensions;

public static class ClaimsPrincipalExtensions
{
    public static Guid GetUserId(this ClaimsPrincipal claimsPrincipal) =>
        (claimsPrincipal.Claims.FirstOrDefault(c => c.Type == nameof(AuthenticationClaim.UserId))?.Value) switch
        {
            var id when id is not null => Guid.Parse(id),
            _ => Guid.Empty
        };

    public static string? GetUsername(this ClaimsPrincipal claimsPrincipal) =>
        claimsPrincipal.Claims.FirstOrDefault(c => c.Type == nameof(AuthenticationClaim.Username))?.Value;

    public static User AsUser(this ClaimsPrincipal? claimsPrincipal) =>
        new User(claimsPrincipal?.GetUserId() ?? Guid.Empty, claimsPrincipal?.GetUsername() ?? string.Empty);
}