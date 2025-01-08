using Nexus.Meetings.Application.Commands.Meetings.Create;
using Nexus.Meetings.Endpoints.Meetings.Routing;
using Nexus.Shared.Endpoints.Api;

namespace Nexus.Meetings.Endpoints.Meetings;

public class Create() : PostEndpoint<CreateMeetingCommand, CreateMeetingCommandResult>(MeetingsRouting.Create)
{
}