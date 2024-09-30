using Nexus.Shared.Mediator;
using Nexus.Shared.Mediator.Cqrs;

namespace Nexus.Meetings.Application.Commands.Create;

public class CreateMeetingHandler 
    // : ICommandHandler<CreateMeeting,CreateMeetingResult>
{
    public Task<CreateMeetingResult> Handle(CreateMeeting request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}