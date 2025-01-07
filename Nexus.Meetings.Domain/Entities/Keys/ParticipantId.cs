using Nexus.Shared.Domain.Domain;

namespace Nexus.Meetings.Domain.Entities.Keys;

public sealed record ParticipantId(Ulid Id) : EntityId<Ulid>(Id);