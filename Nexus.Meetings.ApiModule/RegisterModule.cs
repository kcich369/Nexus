using Microsoft.Extensions.DependencyInjection;
using Nexus.Meetings.Application;
using Nexus.Meetings.Infrastructure;

namespace Nexus.Meetings.ApiModule;

public static class RegisterModule
{
    public static IServiceCollection RegisterMeetingEndpoints(this IServiceCollection services)
    {
         services.RegisterApplication();
         return services.RegisterInfrastructure();
         return services.RegisterInfrastructure();
    }
}