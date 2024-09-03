using Nexus.Shared.Domain.Domain;

namespace Nexus.Meetings.Domain.DomainKeys;

public sealed record ParticipantId(Ulid Id) : EntityId<Ulid>(Id);