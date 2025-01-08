using Nexus.Shared.Cqrs.Interfaces;
using Nexus.Shared.Domain.Result;

namespace Nexus.Meetings.Application.Commands.Meetings.Create;

public record CreateMeetingCommand(string Value) : ICommand<CreateMeetingCommandResult>;

public record CreateMeetingCommandResult(string Info) : ICommandResult;
