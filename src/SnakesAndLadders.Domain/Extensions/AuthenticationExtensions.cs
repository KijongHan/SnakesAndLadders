using SnakesAndLadders.Domain.Models;

namespace SnakesAndLadders.Domain.Extensions;

public static class AuthenticationExtensions
{
    public static string Name(this AuthenticationScheme scheme)
    {
        return scheme switch
        {
            AuthenticationScheme.JWT => "JWTAuthentication",
            AuthenticationScheme.Cookie => "CookieAuthentication",
            _ => ""
        };
    }
}