using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;
using MongoDB.Entities;
using LicenceShop.Application.Common.Interfaces;
using LicenceShop.Infrastructure.Auth;
using LicenceShop.Infrastructure.Configuration;

namespace LicenceShop.Infrastructure;

public static class DependencyInjection
{

    public static IServiceCollection AddInfrastructure(this IServiceCollection serviceCollection, IConfiguration configuration)
    {

        var mongoDbConfiguration = new MongoDbConfiguration();
        configuration.GetSection("MongoDbConfiguration").Bind(mongoDbConfiguration);
        
        Task.Run(async () =>
        {

            await DB.InitAsync(mongoDbConfiguration.DatabaseName!,
                MongoClientSettings.FromConnectionString(mongoDbConfiguration.ConnectionString));

        }).GetAwaiter().GetResult();
        
        
        serviceCollection.Configure<JwtConfiguration>(configuration.GetSection("JwtConfiguration"));
        serviceCollection.Configure<MongoDbConfiguration>(configuration.GetSection("MongoDbConfiguration"));

        serviceCollection.AddScoped<IAuthService, AuthService>();
        serviceCollection.AddScoped<IUserService, UserService>();
        
        
        return serviceCollection;
    }

}