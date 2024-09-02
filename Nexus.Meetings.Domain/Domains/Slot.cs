using Nexus.Meetings.Domain.DomainKeys;
using Nexus.Meetings.Domain.ValueObjects;
using Nexus.Shared.Domain.Domain;

namespace Nexus.Meetings.Domain.Domains;

public sealed class Slot : Entity<SlotId>
{
    public Duration Duration { get; private set; }
    
    public Meeting Meeting { get; private set; }
}