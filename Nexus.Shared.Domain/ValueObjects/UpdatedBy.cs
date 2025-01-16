using Nexus.Shared.Domain.DomainResults;
using Nexus.Shared.Domain.DomainResults.Abstractions;
using Nexus.Shared.Domain.Guards;
using Nexus.Shared.Domain.Results;
using Nexus.Shared.Domain.ValueObjects.Base;

namespace Nexus.Shared.Domain.ValueObjects;

public sealed record UpdatedBy : ValueObject
{
    public string Value { get; private set; }

    private UpdatedBy()
    {
    }

    private UpdatedBy(string value)
    {
        Value = value;
    }

    public static IDomainResult<UpdatedBy> Create(string userName)
    {
        var result = StringGuard.Create(userName)
            .HasMaxValue(50)
            .NotNullAndEmpty()
            .ToDomainResult();
        
        return result.MapToResult(new UpdatedBy(userName));
    }
}