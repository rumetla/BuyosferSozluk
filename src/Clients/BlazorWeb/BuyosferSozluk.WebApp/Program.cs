using BuyosferSozluk.WebApp;
using BuyosferSozluk.WebApp.Infrastructure.Services;
using BuyosferSozluk.WebApp.Infrastructure.Services.Interfaces;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");


builder.Services.AddHttpClient("WebApiClient", client =>
{
    client.BaseAddress = new Uri("https://localhost:5001");
}); // TODO AuthTokenHandler will be here

builder.Services.AddScoped(sp =>
{
    var clientFactory = sp.GetRequiredService<IHttpClientFactory>();

    return clientFactory.CreateClient("WebApiClient");
});

builder.Services.AddTransient<IVoteService, VoteService>();


builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

await builder.Build().RunAsync();
