namespace SnakesAndLadders.Domain.Models;

public enum AuthenticationClaim
{
    Username,
    UserId,

    UserRole
}

public static class Authentication
{
    public const string CorsPolicy = "LocalhostCorsPolicy";
}