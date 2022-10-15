using Blazored.SessionStorage;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using SnakesAndLadders.Domain.Repositories;
using SnakesAndLadders.Infrastructure;
using SnakesAndLadders.Web.UI;
using SnakesAndLadders.Web.UI.Repositories;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services
    .AddBlazoredSessionStorage()
    .AddScoped<IAuthenticationTokenRepository, SessionAuthenticationTokenRepository>()
    .AddSingleton(sp => new HttpClient { BaseAddress = new Uri($"https://localhost:{7268}") });

await builder.Build().RunAsync();
