using Nexus.Meetings.Domain.Entities.Keys;
using Nexus.Meetings.Domain.ValueObjects;
using Nexus.Shared.Domain.Domain;

namespace Nexus.Meetings.Domain.AggregateRoots;

public sealed class Slot : AggregateRoot<SlotId>
{
    public Duration Duration { get; private set; }
    
    public MeetingId MeetingId { get; private set; }
    public Meeting Meeting { get; private set; }
}