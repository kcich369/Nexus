using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace Nexus.Shared.Mediator;

public static class _RegisterMediator
{
    public static IServiceCollection RegisterMediator(this IServiceCollection services)
    {
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
        return services;
    }
}