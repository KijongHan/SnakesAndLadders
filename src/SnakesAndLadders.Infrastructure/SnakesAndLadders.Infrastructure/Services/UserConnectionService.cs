using SnakesAndLadders.Domain.Models;
using SnakesAndLadders.Domain.Services;

namespace SnakesAndLadders.Infrastructure.Services;

internal class UserConnectionService : IUserConnectionService
{
    private readonly IDictionary<Guid, UserConenction> userConnections;

    public UserConnectionService()
    {
        userConnections = new Dictionary<Guid, UserConenction>();
    }

    public UserConenction? TryGetUserConnection(Guid userId)
    {
        if (userConnections.TryGetValue(userId, out var userConnection))
        {
            return userConnection;
        }
        return null;
    }

    public bool TryRemoveUserConnection(Guid userId)
    {
        return userConnections.Remove(userId);
    }

    public bool TrySaveUserConnection(Guid userId, string connectionId)
    {
        if (userConnections.TryAdd(userId, new UserConenction(userId, connectionId)))
        {
            return true;
        }
        return false;
    }
}
