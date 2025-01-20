using Microsoft.Extensions.DependencyInjection;

namespace Nexus.Meetings.ApiModule.Endpoints;

public static class RegisterEndpoints
{
    public static IServiceCollection RegisterMeetingEndpoints(this IServiceCollection services)
    {
        return services;
    }
}