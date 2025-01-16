using Nexus.Shared.Cqrs.Interfaces;
using Nexus.Shared.Domain.Results;
using Nexus.Shared.Domain.Results.Abstractions;

namespace Nexus.Meetings.Application.Commands.Meetings.Create;

public class CreateMeetingHandler : ICommandHandler<CreateMeetingCommand, CreateMeetingCommandResult>
{
    public async ValueTask<IResult<CreateMeetingCommandResult>> Handle(CreateMeetingCommand command,
        IValidationContext<CreateMeetingCommand> validationContext, CancellationToken token)
    {
        var a = "HANDLER";
        return OkResult<CreateMeetingCommandResult>.Create(new CreateMeetingCommandResult("WORKS"));
    }
}