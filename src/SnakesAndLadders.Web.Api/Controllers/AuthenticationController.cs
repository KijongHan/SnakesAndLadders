using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication;
using SnakesAndLadders.Domain.Extensions;
using SnakesAndLadders.Domain.Models;
using SnakesAndLadders.Domain.Services;
using SnakesAndLadders.Web.Api.Dtos;
using IAuthenticationService = SnakesAndLadders.Domain.Services.IAuthenticationService;

namespace SnakesAndLadders.Web.Api.Controllers;

public class AuthenticationController : Controller
{
    private IAuthenticationService authenticationService;

    public AuthenticationController(IAuthenticationService authenticationService)
    {
        this.authenticationService = authenticationService;
    }

    [Route("guest/login")]
    [HttpPost]
    public async Task<IActionResult> GuestLoginAsync([FromBody] PostGuestLogin loginEntity)
    {
       if (await authenticationService.TryAuthenticateGuestAsync(loginEntity.Guestname, out var claimsPrincipal))
       {

       }
       else
       {
            return NotFound();
       }

        await HttpContext.SignInAsync
            (
                authenticationService.GetAuthenticationScheme().Name(), claimsPrincipal
            );
        return Ok(claimsPrincipal.ApiGetUser());
    }
}