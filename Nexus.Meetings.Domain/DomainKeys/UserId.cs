using Nexus.Shared.Domain.Domain;

namespace Nexus.Meetings.Domain.DomainKeys;

public sealed record UserId(Ulid Id) : EntityId<Ulid>(Id);