using BuyosferSozluk.Api.Application.Interfaces.Repositories;
using BuyosferSozluk.Api.Infrastructure.Persistence.Context;
using BuyosferSozluk.Api.Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BuyosferSozluk.Api.Infrastructure.Persistence.Extensions;

public static class Registration
{
    public static IServiceCollection AddInfrastructureRegistration(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<BuyosferSozlukContext>(conf =>
        {
            var connStr = configuration["BuyosferSozlukDbConnectionString"].ToString();
            conf.UseSqlServer(connStr, opt =>
            {
                opt.EnableRetryOnFailure();
            });
        });

        //var seedData = new SeedData();
        //seedData.SeedAsync(configuration).GetAwaiter().GetResult();

      services.AddScoped<IUserRepository, UserRepository>();
      services.AddScoped<IEmailConfirmationRepository, EmailConfirmationRepository>();
      services.AddScoped<IEntryRepository, EntryRepository>();
      services.AddScoped<IEntryCommentRepository, EntryCommentRepository>();

        return services;
    }
}