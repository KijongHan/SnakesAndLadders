namespace SnakesAndLadders.Web.Api.Extensions;

internal static class ChatExtensions
{
    public static Dtos.ChatMessage AsDtoChatMessage(this Domain.Models.ChatMessage message) => 
        new Dtos.ChatMessage(message.User.UserId, message.Message, message.CreatedDateTimeOffset);

    public static Dtos.ChatRoom AsDtoChatRoom(this Domain.Models.ChatRoom room) =>
        new Dtos.ChatRoom(room.ChatRoomId, room.ChatRoomName);
}