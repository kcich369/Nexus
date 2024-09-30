using Nexus.Shared.Domain.Result;
using Nexus.Shared.Mediator;

namespace Nexus.Meetings.Application.Commands.Create;

public record CreateMeeting(string Value) : ICommand<IResult<CreateMeetingResult>>;
