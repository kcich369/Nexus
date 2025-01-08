using Nexus.Shared.Endpoints.Routes;

namespace Nexus.Meetings.Endpoints.Meetings.Routing;

public abstract class MeetingsRouting : Route<MeetingsRouting>
{
    public static ApiEndpointRoute Create => CreateRoute(nameof(Create));
}