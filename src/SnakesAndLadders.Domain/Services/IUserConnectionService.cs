using SnakesAndLadders.Domain.Models;

namespace SnakesAndLadders.Domain.Services;

public interface IUserConnectionService
{
    public bool TrySaveUserConnection(Guid userId, string connectionId);

    public bool TryRemoveUserConnection(Guid userId);

    public UserConenction? TryGetUserConnection(Guid userId);
}