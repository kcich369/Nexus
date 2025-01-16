using Nexus.Shared.Cqrs.Interfaces;
using Nexus.Shared.Domain.Results;
using Nexus.Shared.Domain.Results.Abstractions;

namespace Nexus.Meetings.Application.Commands.Meetings.Create;

public class CreateMeetingValidator : ICommandValidator<CreateMeetingCommand, CreateMeetingCommandResult>
{
    public async ValueTask<IResult<IValidationContext<CreateMeetingCommand>>> Validate(CreateMeetingCommand command,
        CancellationToken token)
    {
        var a = "VALIDATOR";
        return OkResult<CreateMeetingCommandValidationContext>.Create(new CreateMeetingCommandValidationContext(11));
    }
}