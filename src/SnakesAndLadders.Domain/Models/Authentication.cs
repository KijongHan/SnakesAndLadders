namespace SnakesAndLadders.Domain.Models;

public enum AuthenticationClaim
{
    Username,
    UserId,

    UserRole
}

public enum AuthenticationScheme
{
    Cookie,
    JWT
}