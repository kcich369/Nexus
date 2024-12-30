namespace Nexus.Shared.Endpoints.Routes;

public sealed class MeetingsRoutes : Route<MeetingsRoutes>
{
    public static ApiEndpointRoute Create = CreateEndpoint(nameof(Create));
}