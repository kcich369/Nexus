using Nexus.Shared.Domain.Domain;

namespace Nexus.Meetings.Domain.DomainKeys;

public sealed record Userid(Ulid Id) : EntityId<Ulid>(Id);