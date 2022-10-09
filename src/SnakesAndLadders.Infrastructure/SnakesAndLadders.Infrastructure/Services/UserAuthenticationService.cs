using Microsoft.IdentityModel.Tokens;
using SnakesAndLadders.Domain.Extensions;
using SnakesAndLadders.Domain.Models;
using SnakesAndLadders.Domain.Repositories;
using SnakesAndLadders.Domain.Services;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace SnakesAndLadders.Infrastructure.Services;

internal class UserAuthenticationService : IUserAuthenticationService
{
    private object serviceLock;

    private IGuestLoginRepository guestLoginRepository;

    public UserAuthenticationService(IGuestLoginRepository guestLoginRepository)
    {
        serviceLock = new object();
        this.guestLoginRepository = guestLoginRepository;
    }

    public string GenerateJwtToken(ClaimsPrincipal claimsPrincipal)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var tokenKey = Encoding.UTF8.GetBytes("secret key test secret key test secret key test secret key test");
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = claimsPrincipal.Identities.FirstOrDefault(),
            Expires = DateTime.UtcNow.AddMinutes(10),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256Signature)
        };
        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }

    public async Task<ClaimsPrincipal?> TryAuthenticateGuestAsync(string guestname, string authenticationScheme)
    {
        var guest = await guestLoginRepository.TryCreateGuestLogin(new Guest(Guid.NewGuid(), guestname));
        if (guest is not null)
        {
            return guest.GetClaimsPrincipal(authenticationScheme);
        }
        return null;
    }
}
