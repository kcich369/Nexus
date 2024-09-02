using Nexus.Shared.Domain.Guards;
using Nexus.Shared.Domain.Result;
using Nexus.Shared.Domain.ValueObjects.Base;

namespace Nexus.Shared.Domain.ValueObjects;

public sealed record CreatedAt : ValueObject
{
    public DateTime Value { get; private set; }

    private CreatedAt()
    {
    }

    private CreatedAt(DateTime value)
    {
        Value = value;
    }

    public static DomainResult<CreatedAt> Create(DateTime createdAt)
    {
        var result = DateTimeGuard.Create(createdAt)
            .HasCurrentDate()
            .ToDomainResult();
        return result
            ? DomainResult<CreatedAt>.Error(result)
            : DomainResult<CreatedAt>.Success(new(createdAt));
    }
}