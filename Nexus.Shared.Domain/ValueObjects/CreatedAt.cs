using Nexus.Shared.Domain.DomainResults;
using Nexus.Shared.Domain.DomainResults.Abstractions;
using Nexus.Shared.Domain.Guards;
using Nexus.Shared.Domain.Results;
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

    public static IDomainResult<CreatedAt> Create(DateTime createdAt)
    {
        var result = DateTimeGuard.Create(createdAt)
            .HasCurrentDate()
            .ToDomainResult();
        
        return result.IsError
            ? ErrorDomainResult<CreatedAt>.Create(result.ErrorMessages)
            : SuccessDomainResult<CreatedAt>.Create(new CreatedAt(createdAt));
    }
}