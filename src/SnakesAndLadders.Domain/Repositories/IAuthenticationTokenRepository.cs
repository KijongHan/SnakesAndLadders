using SnakesAndLadders.Domain.Models;

namespace SnakesAndLadders.Domain.Repositories;

public interface IAuthenticationTokenRepository
{
    public Task SaveAuthorizationToken(JwtToken? token);

    public Task<JwtToken?> GetAuthorizationToken();
}
