using SnakesAndLadders.Domain.Models;
using SnakesAndLadders.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakesAndLadders.Domain.Extensions;

public static class ChatExtensions
{
    public static IEnumerable<string> GetUsersConnections(this ChatRoom chatRoom, Func<User, UserConenction?> getUserConnection)
    {
        return chatRoom.Users.Select(u => getUserConnection(u)).Where(u => u is not null).Select(u => u!.ConnectionId);
    }
}
