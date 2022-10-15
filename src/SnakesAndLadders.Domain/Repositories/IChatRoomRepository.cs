using SnakesAndLadders.Domain.Models;

namespace SnakesAndLadders.Domain.Repositories;

public interface IChatRoomRepository
{
    public Task<List<ChatRoom>> GetPublicChatRooms();

    public Task<ChatRoom?> TryGetChatRoom(Guid chatRoomId);

    public bool TryJoinChatRoom(Guid chatRoomId, User user, out ChatRoom? chatRoom);

    public void AddChatMessage(ChatMessage chatMessage);
}