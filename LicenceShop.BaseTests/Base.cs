using AutoMapper;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using LicenceShop.BaseTests;

namespace LicenceShop.BaseTests;

public class Base
{
    public readonly HttpClient annonymousClient;
    public readonly IMapper Mapper;
    private readonly IMediator mediator;


    public Base()
    {
        var factory = new CustomWebApplicationFactory<Program>();
        var scope = factory.Services.GetRequiredService<IServiceScopeFactory>().CreateScope();

        annonymousClient = factory.CreateClient();

        mediator = scope.ServiceProvider.GetRequiredService<IMediator>();
        Mapper = scope.ServiceProvider.GetRequiredService<IMapper>();

    }
}