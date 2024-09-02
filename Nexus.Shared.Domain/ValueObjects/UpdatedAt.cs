using Nexus.Shared.Domain.Guards;
using Nexus.Shared.Domain.Result;
using Nexus.Shared.Domain.ValueObjects.Base;

namespace Nexus.Shared.Domain.ValueObjects;

public sealed record UpdatedAt : ValueObject
{
    public DateTime Value { get; private set; }

    private UpdatedAt()
    {
    }

    private UpdatedAt(DateTime value)
    {
    }

    public static DomainResult<UpdatedAt> Create(DateTime updatedAt)
    {
        var result = DateTimeGuard.Create(updatedAt)
            .HasCurrentDate()
            .ToDomainResult();
        return result
            ? DomainResult<UpdatedAt>.Error(result)
            : DomainResult<UpdatedAt>.Success(new(updatedAt));
    }
}