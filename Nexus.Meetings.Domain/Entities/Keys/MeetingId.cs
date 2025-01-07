using Nexus.Shared.Domain.Domain;

namespace Nexus.Meetings.Domain.Entities.Keys;

public sealed record MeetingId(Ulid Id) : EntityId<Ulid>(Id);