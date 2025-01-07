using Microsoft.Extensions.DependencyInjection;
using Nexus.Meetings.Infrastructure;

namespace Nexus.Meetings.Endpoints;

public static class _RegisterEndpoints
{
    public static IServiceCollection RegisterMeetingEndpoints(this IServiceCollection services)
    {
        return services.RegisterInfrastructure();
    }
}