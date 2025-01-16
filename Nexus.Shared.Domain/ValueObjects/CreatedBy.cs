using Nexus.Shared.Domain.DomainResults;
using Nexus.Shared.Domain.DomainResults.Abstractions;
using Nexus.Shared.Domain.Guards;
using Nexus.Shared.Domain.Results;
using Nexus.Shared.Domain.ValueObjects.Base;

namespace Nexus.Shared.Domain.ValueObjects;

public sealed record CreatedBy : ValueObject
{
    public string Value { get; private set; }

    private CreatedBy()
    {
    }

    private CreatedBy(string value)
    {
        Value = value;
    }

    public static IDomainResult<CreatedBy> Create(string userName)
    {
        var result = StringGuard.Create(userName)
            .HasMaxValue(50)
            .NotNullAndEmpty()
            .ToDomainResult();
        
        return result.IsError
            ? ErrorDomainResult<CreatedBy>.Create(result.ErrorMessages)
            : SuccessDomainResult<CreatedBy>.Create(new CreatedBy(userName));
    }
}