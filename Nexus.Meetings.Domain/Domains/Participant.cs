using Nexus.Meetings.Domain.DomainKeys;
using Nexus.Meetings.Domain.ValueObjects;

namespace Nexus.Meetings.Domain.Domains;

public sealed class Participant
{
    public ParticipantId Id { get; private set; }
    public Name Name { get; private set; }
    public Surname Surname { get; private set; }
    public PhoneNumber Phone { get; private set; }
    public Email Email { get; private set; }

    public MeetingId MeetingId { get; private set; }
    public Meeting Meeting { get; private set; }

}