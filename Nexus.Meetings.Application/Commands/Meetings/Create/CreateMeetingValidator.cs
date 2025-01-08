using Nexus.Shared.Cqrs.Interfaces;
using Nexus.Shared.Domain.Result;

namespace Nexus.Meetings.Application.Commands.Meetings.Create;

public class CreateMeetingValidator : ICommandValidator<CreateMeetingCommand,CreateMeetingCommandResult>
{
    public async ValueTask<IResult<CreateMeetingCommand>> Validate(CreateMeetingCommand command, CancellationToken token)
    {
        var a = "VALIDATOR";
        return Result<CreateMeetingCommand>.Success(command);
    }
}