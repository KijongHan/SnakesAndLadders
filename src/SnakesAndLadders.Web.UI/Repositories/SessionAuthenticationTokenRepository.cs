using Blazored.SessionStorage;
using SnakesAndLadders.Domain.Models;
using SnakesAndLadders.Domain.Repositories;

namespace SnakesAndLadders.Web.UI.Repositories;

internal class SessionAuthenticationTokenRepository : IAuthenticationTokenRepository
{
    private ISessionStorageService sessionStorage;

    public SessionAuthenticationTokenRepository(ISessionStorageService sessionStorage)
    {
        this.sessionStorage = sessionStorage;
    }

    public async Task<JwtToken?> GetAuthorizationToken()
    {
        return await sessionStorage.GetItemAsync<JwtToken>("jwtToken");
    }

    public async Task SaveAuthorizationToken(JwtToken? jwt)
    {
        await sessionStorage.SetItemAsync("jwtToken", jwt!);
    }
}
