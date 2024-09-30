using Microsoft.Extensions.DependencyInjection;
using Nexus.Shared.Mediator;

namespace Nexus.Meetings.Application;

public static class _RegisterApplication
{
    public static IServiceCollection RegisterApplication(this IServiceCollection services)
    {
        return services.RegisterCqrs();
    }
}