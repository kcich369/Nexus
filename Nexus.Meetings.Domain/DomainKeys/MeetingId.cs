using Nexus.Shared.Domain.Domain;

namespace Nexus.Meetings.Domain.DomainKeys;

public sealed record MeetingId(Ulid Id) : EntityId<Ulid>(Id);