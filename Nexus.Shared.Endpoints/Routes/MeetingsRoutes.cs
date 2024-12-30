namespace Nexus.Shared.Endpoints.Routes;

public class MeetingsRoutes : Route<MeetingsRoutes>
{
    public static ApiEndpointRoute CreateMeeting => CreateEndpoint(nameof(CreateMeeting));
}