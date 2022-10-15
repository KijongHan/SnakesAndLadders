namespace SnakesAndLadders.Domain.Models;

public record ChatRoom(Guid ChatRoomId, bool IsPublic, string ChatRoomName, IDictionary<Guid, User> Users);

public record ChatMessage(Guid MessageId, User User, string Message, DateTimeOffset CreatedDateTimeOffset);