using Nexus.Shared.Cqrs.Interfaces;
using Nexus.Shared.Domain.Result;
using Nexus.Shared.Mediator;
using Nexus.Shared.Mediator.Cqrs;

namespace Nexus.Meetings.Application.Commands.Create;

public record CreateMeeting(string Value) : ICommand<IResult<CreateMeetingResult>>;
