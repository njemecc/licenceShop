using System.Reflection;
using FluentValidation;
using LicenceShop.Application.Common.Behaviours;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace LicenceShop.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection serviceCollection)
    {

        serviceCollection.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        serviceCollection.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
        
        serviceCollection.AddTransient(typeof(IPipelineBehavior<,>),
            typeof(UnhandledExceptionBehaviour<,>));
        serviceCollection.AddTransient(typeof(IPipelineBehavior<,>),
            typeof(ValidationBehaviour<,>));
        
        
        return serviceCollection;
    }
}