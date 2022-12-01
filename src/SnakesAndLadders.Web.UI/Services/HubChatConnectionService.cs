using Microsoft.AspNetCore.SignalR.Client;
using SnakesAndLadders.Web.Dto.Endpoints;
using SnakesAndLadders.Web.Dto.Hub;
using SnakesAndLadders.Web.Dto.Services;
using SnakesAndLadders.Web.UI.Middleware;

namespace SnakesAndLadders.Web.UI.Services;

public class HubChatConnectionService : ChatConnectionService
{
    private HttpClient httpClient;
    private HubConnection? hubConnection;

    public HubChatConnectionService(HttpClient httpClient)
    {
        this.httpClient = httpClient;
    }

    public override async Task InitializeAsync()
    {
        hubConnection = new HubConnectionBuilder()
            .WithUrl($"{httpClient.BaseAddress}chathub", options =>
            {
                options.Headers.Add("Authorization", httpClient.DefaultRequestHeaders.Authorization.ToString());
            })
            .Build();

        hubConnection.On<ChatSendMessage>(ChatHubEndpoints.ChatSendMessage, (chatSendMessage) =>
        {
            InvokeChatSendMessageEvent(new ChatSendMessageEvent(chatSendMessage.ChatMessage));
        });

        hubConnection.On<ChatJoin>(ChatHubEndpoints.ChatJoin, (chatJoin) =>
        {
            InvokeChatJoinMessageEvent(new ChatJoinEvent(chatJoin.UpdatedChatRoom));
        });

        await hubConnection.StartAsync();
    }

    public async override Task JoinChatRoomAsync(Guid chatRoomId)
    {
        await hubConnection!.SendAsync(ChatHubEndpoints.ChatJoin, chatRoomId);
    }
}