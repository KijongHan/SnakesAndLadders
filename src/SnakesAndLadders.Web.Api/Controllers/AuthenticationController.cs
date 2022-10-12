using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication;
using SnakesAndLadders.Web.Api.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using SnakesAndLadders.Domain.Services;

namespace SnakesAndLadders.Web.Api.Controllers;

public class AuthenticationController : Controller
{
    private IUserAuthenticationService authenticationService;

    public AuthenticationController(IUserAuthenticationService authenticationService)
    {
        this.authenticationService = authenticationService;
    }

    [AllowAnonymous]
    [Route("guest/login")]
    [HttpPost]
    public async Task<IActionResult> GuestLoginAsync([FromBody] PostGuestLogin loginEntity)
    {
        var claimsPrincipal = await authenticationService.TryAuthenticateGuestAsync(loginEntity.Guestname, JwtBearerDefaults.AuthenticationScheme);
       if (claimsPrincipal is not null)
       {
            return Ok(authenticationService.GenerateJwtToken(claimsPrincipal));
       }
       else
       {
            return Unauthorized();
       }
    }
}