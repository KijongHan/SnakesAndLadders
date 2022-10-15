using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using SnakesAndLadders.Domain.Models;
using SnakesAndLadders.Domain.Repositories;
using SnakesAndLadders.Web.Dto.Extensions;

namespace SnakesAndLadders.Web.Api.Controllers;

[EnableCors(Authentication.CorsPolicy)]
public class ChatRoomsController : Controller
{
    private readonly IChatRoomRepository chatRoomRepository;

    public ChatRoomsController(IChatRoomRepository chatRoomRepository)
    {
        this.chatRoomRepository = chatRoomRepository;
    }

    [Authorize]
    [Route("chatrooms/public")]
    [HttpGet]
    public async Task<IActionResult> GetPublicChatrooms()
    {
        var chatRooms = await chatRoomRepository.GetPublicChatRooms();
        return Ok(chatRooms.Select(c => c.AsDtoChatRoom()));
    }
}
