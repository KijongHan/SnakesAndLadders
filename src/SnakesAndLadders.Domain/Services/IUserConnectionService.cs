using SnakesAndLadders.Domain.Models;

namespace SnakesAndLadders.Domain.Services;

public interface IUserConnectionService
{
    public bool TrySaveUserConnection(Guid userId, string connectionId);

    public UserConenction? TryGetUserConnection(Guid userId);
}