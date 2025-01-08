using Nexus.Shared.Cqrs.Interfaces;
using Nexus.Shared.Domain.Result;

namespace Nexus.Meetings.Application.Commands.Meetings.Create;

public class CreateMeetingHandler : ICommandHandler<CreateMeetingCommand, CreateMeetingCommandResult>
{
    public ValueTask<IResult<CreateMeetingCommandResult>> Handle(CreateMeetingCommand command, CancellationToken token)
    {
        throw new NotImplementedException();
    }
}