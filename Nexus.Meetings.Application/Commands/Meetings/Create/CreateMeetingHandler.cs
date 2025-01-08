using Nexus.Shared.Cqrs.Interfaces;
using Nexus.Shared.Domain.Result;

namespace Nexus.Meetings.Application.Commands.Meetings.Create;

public class CreateMeetingHandler : ICommandHandler<CreateMeetingCommand, CreateMeetingCommandResult>
{
    public async ValueTask<IResult<CreateMeetingCommandResult>> Handle(CreateMeetingCommand command, CancellationToken token)
    {
        var a = "HANDLER";
        return Result<CreateMeetingCommandResult>.Success(new CreateMeetingCommandResult("WORKS"));
    }
}