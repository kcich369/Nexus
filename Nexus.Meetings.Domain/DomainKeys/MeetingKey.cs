using Nexus.Shared.Domain.Domain;

namespace Nexus.Meetings.Domain.DomainKeys;

public sealed record MeetingKey(Ulid Id) : EntityKey<Ulid>(Id);