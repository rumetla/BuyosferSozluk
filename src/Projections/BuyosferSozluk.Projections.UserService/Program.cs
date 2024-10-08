using BuyosferSozluk.Projections.UserService;
using BuyosferSozluk.Projections.UserService.Services;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        services.AddHostedService<Worker>();
        services.AddTransient<UserService>();
        services.AddTransient<EmailService>();
    })
    .Build();

await host.RunAsync();