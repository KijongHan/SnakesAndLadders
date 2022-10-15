using SnakesAndLadders.Domain.Repositories;
using System.Net;

namespace SnakesAndLadders.Infrastructure.UI.Repositories;

internal class SessionStorageAuthenticationTokenRepository : IAuthenticationTokenRepository
{
    public SessionStorageAuthenticationTokenRepository(ProtectedSessionStorage protectedSessionStorage)
    {

    }

    public string? GetAuthorizationToken()
    {
        throw new NotImplementedException();
    }

    public void SaveAuthorizationToken(string token)
    {
        throw new NotImplementedException();
    }
}
