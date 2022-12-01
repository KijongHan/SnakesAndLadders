namespace SnakesAndLadders.Web.Dto.Services;

public abstract class ChatConnectionService
{
    public static event EventHandler<ChatSendMessageEvent>? ChatSendMessageEvent;
    public static event EventHandler<ChatJoinEvent>? ChatJoinEvent;

    protected void InvokeChatSendMessageEvent(ChatSendMessageEvent e) => ChatSendMessageEvent?.Invoke(this, e);
    protected void InvokeChatJoinMessageEvent(ChatJoinEvent e) => ChatJoinEvent?.Invoke(this, e);

    public abstract Task InitializeAsync();

    public abstract Task JoinChatRoomAsync(Guid chatRoomId);
}

public record ChatSendMessageEvent(ChatMessage ChatMessage);

public record ChatJoinEvent(ChatRoom UpdatedChatRoom);