using Nexus.Meetings.ApiModule.Meetings.Routing;
using Nexus.Meetings.Application.Commands.Meetings.Create;
using Nexus.Shared.Endpoints.Api;

namespace Nexus.Meetings.ApiModule.Meetings;

public class Create() : PostEndpoint<CreateMeetingCommand, CreateMeetingCommandResult>(MeetingsRouting.Create)
{
}