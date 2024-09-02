using Nexus.Meetings.Domain.DomainKeys;
using Nexus.Shared.Domain.Domain;

namespace Nexus.Meetings.Domain.Domains;

public sealed class Meeting :  AggregateRoot<MeetingKey>
{
    public UserId UserId { get; private set; }
    public User User { get; private set; } 
    
    public SlotId SlotId { get; private set; }
    public Slot Slot { get; private set; }
    
    public Note Note { get; private set; }
}