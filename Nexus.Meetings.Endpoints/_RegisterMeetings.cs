using Microsoft.Extensions.DependencyInjection;
using Nexus.Meetings.Infrastructure;

namespace Nexus.Meetings.Endpoints;

public static class _RegisterMeetings
{
    public static IServiceCollection ReqisterMeetingsModule(this IServiceCollection services)
    {
        return services.RegisterInfrastructure();
    }
}