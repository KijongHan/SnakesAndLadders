namespace SnakesAndLadders.Domain.Models;

public record User(Guid UserId, string UserName);

public record UserConenction(Guid UserId, string ConnectionId);