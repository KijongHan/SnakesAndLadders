namespace SnakesAndLadders.Web.Dto;

public record ChatMessage(Guid SenderUserId, string Message, DateTimeOffset CreatedDateTimeOffset);

public record ChatRoom(Guid ChatRoomId, string ChatRoomName);