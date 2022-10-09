using SnakesAndLadders.Domain.Models;

namespace SnakesAndLadders.Domain.Repositories;

public interface IGuestLoginRepository
{
    public Task<Guest?> TryCreateGuestLogin(Guest guestForm);

    public Task<bool> TryRemoveGuestLogin(Guid id);
}