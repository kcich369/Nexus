using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using Nexus.Shared.Mediator.Cqrs;

namespace Nexus.Shared.Mediator;

public static class _RegisterMediator
{
    public static IServiceCollection RegisterMediator(this IServiceCollection services)
    {
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
        services.AddScoped<IDispatcher, Dispatcher>();
        return services;
    }
}