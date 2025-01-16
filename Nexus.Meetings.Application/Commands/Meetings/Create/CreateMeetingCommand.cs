using Nexus.Shared.Cqrs.Interfaces;

namespace Nexus.Meetings.Application.Commands.Meetings.Create;

public record CreateMeetingCommand(string Value) : ICommand<CreateMeetingCommandResult>;

public record CreateMeetingCommandResult(string Info) : ICommandResult;
public record CreateMeetingCommandValidationContext(int Id) : IValidationContext<CreateMeetingCommand>;
