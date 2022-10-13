namespace SnakesAndLadders.Web.Dto.Extensions;

public static class ChatExtensions
{
    public static ChatMessage AsDtoChatMessage(this Domain.Models.ChatMessage message) => 
        new ChatMessage(message.User.UserId, message.Message, message.CreatedDateTimeOffset);

    public static ChatRoom AsDtoChatRoom(this Domain.Models.ChatRoom room) =>
        new ChatRoom(room.ChatRoomId, room.ChatRoomName);
}