using SnakesAndLadders.Domain.Models;

namespace SnakesAndLadders.Domain.Extensions;

public static class ChatExtensions
{
    public static IEnumerable<string> GetUsersConnections(this ChatRoom chatRoom, Func<User, UserConenction?> getUserConnection)
    {
        return chatRoom.Users.Select(u => getUserConnection(u.Value)).Where(u => u is not null).Select(u => u!.ConnectionId);
    }
}