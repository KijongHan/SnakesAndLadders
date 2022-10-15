using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using SnakesAndLadders.Domain.Services;
using SnakesAndLadders.Web.Dto;
using Microsoft.AspNetCore.Cors;
using SnakesAndLadders.Domain.Models;

namespace SnakesAndLadders.Web.Api.Controllers;

[EnableCors(Authentication.CorsPolicy)]
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