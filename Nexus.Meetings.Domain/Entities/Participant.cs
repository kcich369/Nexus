using Nexus.Meetings.Domain.Entities.Keys;
using Nexus.Meetings.Domain.ValueObjects;
using Nexus.Shared.Domain.Domain;

namespace Nexus.Meetings.Domain.Entities;

public sealed class Participant: BaseEntity<ParticipantId>
{
    public Name Name { get; private set; }
    public Surname Surname { get; private set; }
    public PhoneNumber Phone { get; private set; }
    public Email Email { get; private set; }
    public UserId UserId { get; private set; }
}