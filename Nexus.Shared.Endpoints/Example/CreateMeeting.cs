using Nexus.Shared.Endpoints.Api;
using Nexus.Shared.Endpoints.Routes;

namespace Nexus.Shared.Endpoints;

public class CreateMeeting() : PostEndpoint<CreateMeetingCommand, CreateMeetingCommandResult>(MeetingsRoutes.Create)
{
}