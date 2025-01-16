using Nexus.Shared.Domain.DomainResults;
using Nexus.Shared.Domain.DomainResults.Abstractions;
using Nexus.Shared.Domain.Guards;
using Nexus.Shared.Domain.Results;
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

    public static IDomainResult<UpdatedAt> Create(DateTime updatedAt)
    {
        var result = DateTimeGuard.Create(updatedAt)
            .HasCurrentDate()
            .ToDomainResult();
        
        return result.MapToResult(new UpdatedAt(updatedAt));
    }
}