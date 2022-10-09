using SnakesAndLadders.Domain.Models;
using SnakesAndLadders.Domain.Repositories;

namespace SnakesAndLadders.Infrastructure.Repositories;

internal class GuestLoginRepository : IGuestLoginRepository
{
    private object repositoryLock;

    private IDictionary<string, Guest> guestLookup;

    public GuestLoginRepository()
    {
        repositoryLock = new object();
        guestLookup = new Dictionary<string, Guest>();
    }

    public Task<Guest?> TryCreateGuestLogin(Guest guestForm)
    {
        lock (repositoryLock)
        {
            return Task.Run(() =>
            {
                var createdGuestForm = guestForm with { Id = Guid.NewGuid() };
                if (guestLookup.TryAdd(createdGuestForm.Username, createdGuestForm))
                {
                    return createdGuestForm;
                }
                return null;
            });
        }
    }

    public Task<bool> TryRemoveGuestLogin(Guid id)
    {
        throw new NotImplementedException();
    }
}
