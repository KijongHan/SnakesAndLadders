using SnakesAndLadders.Domain.Models;
using SnakesAndLadders.Domain.Repositories;
using System.Linq;

namespace SnakesAndLadders.Infrastructure.Repositories;

internal class ChatRoomRepository : IChatRoomRepository
{
    private readonly IDictionary<Guid, ChatRoom> chatRooms;

    public ChatRoomRepository()
    {
        var id = Guid.NewGuid();
        chatRooms = new Dictionary<Guid, ChatRoom> { { id, new ChatRoom(id, true, "General", new Dictionary<Guid, User>() ) } };
    }

    public void AddChatMessage(ChatMessage chatMessage)
    {
        throw new NotImplementedException();
    }

    public Task<List<ChatRoom>> GetPublicChatRooms()
    {
        return Task.Run(() => chatRooms.Values.Where(r => r.IsPublic).ToList());
    }

    public Task<ChatRoom?> TryGetChatRoom(Guid chatRoomId)
    {
        return Task.Run(() =>
        {
            if (chatRooms.TryGetValue(chatRoomId, out var room)) return room;
            return null;
        });
    }

    public bool TryJoinChatRoom(Guid chatRoomId, User user, out ChatRoom? chatRoom)
    {
        if (chatRooms.TryGetValue(chatRoomId, out var currentRoom))
        {
            if (currentRoom.Users.TryAdd(user.UserId, user))
            {
                chatRoom = currentRoom with { Users = currentRoom.Users };
                chatRooms[chatRoomId] = chatRoom;
                return true;
            }
        }

        chatRoom = null;
        return false;
    }
}
