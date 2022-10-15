using Microsoft.AspNetCore.SignalR;
using SnakesAndLadders.Domain.Extensions;
using SnakesAndLadders.Domain.Repositories;
using SnakesAndLadders.Domain.Services;
using SnakesAndLadders.Web.Dto.Extensions;
using Microsoft.AspNetCore.Authorization;
using SnakesAndLadders.Web.Dto.Endpoints;
using Microsoft.AspNetCore.Cors;
using SnakesAndLadders.Domain.Models;

namespace SnakesAndLadders.Web.Api.Hubs;

[Authorize]
[EnableCors(Authentication.CorsPolicy)]
public class ChatHub : Hub
{
    private readonly IUserConnectionService userConnectionService;
    private readonly IChatRoomRepository chatRoomRepository;

    public ChatHub(IUserConnectionService userConnectionService, IChatRoomRepository chatRoomRepository)
    {
        this.userConnectionService = userConnectionService;
        this.chatRoomRepository = chatRoomRepository;
    }

    public Task ChatSendMessage(string message, Guid chatRoomId)
    {
        return Task.Run(async () =>
        {
            var chatRoom = await chatRoomRepository.TryGetChatRoom(chatRoomId);
            var msg = new Domain.Models.ChatMessage(Guid.NewGuid(), Context.User.AsUser(), message, DateTimeOffset.Now);
            if (chatRoom is not null) await Clients.Clients(chatRoom.GetUsersConnections(u => userConnectionService.TryGetUserConnection(u.UserId))).SendAsync(ChatHubEndpoints.ChatSendMessage, msg.AsDtoChatMessage());
        });
    }

    public Task ChatJoin(Guid chatRoomId)
    {
        return Task.Run(async () =>
        {
            var chatRoom = await chatRoomRepository.TryGetChatRoom(chatRoomId);
            if (chatRoom is not null)
            {
                if (chatRoomRepository.TryJoinChatRoom(chatRoomId, Context.User.AsUser(), out var updatedChatRoom))
                    await Clients.Clients(chatRoom.GetUsersConnections(u => userConnectionService.TryGetUserConnection(u.UserId))).SendAsync(ChatHubEndpoints.ChatJoin, updatedChatRoom?.AsDtoChatRoom());
            }
        });
    }

    public override Task OnConnectedAsync()
    {
        return Task.Run(() =>
        {
            userConnectionService.TrySaveUserConnection(Context.User!.GetUserId(), Context.ConnectionId);
        });
    }
}