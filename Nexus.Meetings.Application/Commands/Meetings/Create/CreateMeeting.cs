using Nexus.Shared.Cqrs.Interfaces;
using Nexus.Shared.Domain.Result;

namespace Nexus.Meetings.Application.Commands.Meetings.Create;

public record CreateMeeting(string Value) : ICommand<IResult<CreateMeetingResult>>;
