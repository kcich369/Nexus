using Nexus.Shared.Domain.Domain;

namespace Nexus.Meetings.Domain.DomainKeys;

public sealed record SlotId(Ulid Id) : EntityKey<Ulid>(Id);