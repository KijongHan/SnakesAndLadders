using SnakesAndLadders.Domain.Models;

namespace SnakesAndLadders.Domain.Repositories;

public interface IGuestLoginRepository
{
    public Task<bool> TryCreateGuestLogin(Guest guestForm, out Guest createdGuest);

    public Task<bool> TryRemoveGuestLogin(Guid id);
}