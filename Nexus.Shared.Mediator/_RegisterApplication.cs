using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace Nexus.Shared.Mediator;

public static class _RegisterApplication
{
    public static IServiceCollection RegisterApplication(this IServiceCollection services)
    {
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
        return services;
    }
}