using Nexus.Shared.Cqrs.Interfaces;

namespace Nexus.Shared.Endpoints;

public class CreateMeetingCommand: ICommand<CreateMeetingCommandResult>
{
    public int Id { get; set; }
}