using Nexus.Meetings.Domain.DomainKeys;
using Nexus.Meetings.Domain.Entities;
using Nexus.Meetings.Domain.ValueObjects;
using Nexus.Shared.Domain.Domain;

namespace Nexus.Meetings.Domain.AggregateRoots;

public sealed class Meeting :  AggregateRoot<MeetingId>
{
    public SlotId SlotId { get; private set; }
    public Slot Slot { get; private set; }
    
    public ParticipantId ParticipantId { get; private set; } 
    public Participant Participant { get; private set; } 
    
    public Note Note { get; private set; }
}