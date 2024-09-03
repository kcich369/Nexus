using Nexus.Meetings.Domain.DomainKeys;
using Nexus.Meetings.Domain.ValueObjects;
using Nexus.Shared.Domain.Domain;

namespace Nexus.Meetings.Domain.Domains;

public sealed class Meeting :  AggregateRoot<MeetingId>
{
    public SlotId SlotId { get; private set; }
    public Slot Slot { get; private set; }
    
    public IEnumerable<Participant> Participants { get; private set; } 
    
    public Note Note { get; private set; }
}