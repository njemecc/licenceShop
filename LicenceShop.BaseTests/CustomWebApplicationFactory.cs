using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;
using MongoDB.Driver;
using MongoDB.Entities;

namespace LicenceShop.BaseTests;

public class CustomWebApplicationFactory<TStartup> : WebApplicationFactory<TStartup> where TStartup: class
{
    public CustomWebApplicationFactory()
    {
        Task.Run(async () =>
            {
                await DB.InitAsync("LicenceShopTests",MongoClientSettings
                    .FromConnectionString("mongodb://localhost:27017"));
            })
            .GetAwaiter()
            .GetResult();

    
    }

    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.ConfigureTestServices(services =>
        {
            services.RemoveAll(typeof(IHostedService));
            
            //services.AddScoped(sp=>new MapperMock().Object);
        });

    }
}