using Blazored.SessionStorage;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using SnakesAndLadders.Domain.Repositories;
using SnakesAndLadders.Web.Dto.Services;
using SnakesAndLadders.Web.UI;
using SnakesAndLadders.Web.UI.Repositories;
using SnakesAndLadders.Web.UI.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services
    .AddBlazoredSessionStorage()
    .AddScoped<IAuthenticationTokenRepository, SessionAuthenticationTokenRepository>()
    .AddSingleton<ChatConnectionService, HubChatConnectionService>()
    .AddSingleton(sp => new HttpClient { BaseAddress = new Uri($"https://localhost:{7268}") });

await builder.Build().RunAsync();
