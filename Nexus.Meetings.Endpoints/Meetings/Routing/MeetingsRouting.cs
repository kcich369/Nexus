using Nexus.Shared.Endpoints.Routes;

namespace Nexus.Meetings.Endpoints.Meetings.Routing;

public class MeetingsRouting : Route<MeetingsRouting>
{
    public static ApiEndpointRoute Create => CreateEndpoint(nameof(Create));
}