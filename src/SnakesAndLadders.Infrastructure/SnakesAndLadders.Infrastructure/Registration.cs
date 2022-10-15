using Microsoft.Extensions.DependencyInjection;
using SnakesAndLadders.Domain.Repositories;
using SnakesAndLadders.Domain.Services;
using SnakesAndLadders.Infrastructure.Repositories;
using SnakesAndLadders.Infrastructure.Services;

namespace SnakesAndLadders.Infrastructure;

public static class Registration
{
    public static IServiceCollection AddInfrastructureRegistrations(this IServiceCollection services) =>
        services
            .AddSingleton<IUserAuthenticationService, UserAuthenticationService>()
            .AddSingleton<IUserConnectionService, UserConnectionService>()
            .AddSingleton<IChatRoomRepository, ChatRoomRepository>()
            .AddTransient<IGuestLoginRepository, GuestLoginRepository>();
    
}
