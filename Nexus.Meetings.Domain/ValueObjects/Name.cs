using Nexus.Shared.Domain.DomainResults;
using Nexus.Shared.Domain.DomainResults.Abstractions;
using Nexus.Shared.Domain.Guards;
using Nexus.Shared.Domain.Results;
using Nexus.Shared.Domain.ValueObjects.Base;

namespace Nexus.Meetings.Domain.ValueObjects;

public record Name : ValueObject
{
    public string Value { get; private set; }

    private Name(string name)
    {
        Value = name;
    }

    public static IDomainResult<Name> Create(string name)
    {
        var result = StringGuard.Create(name)
            .NotNullAndEmpty()
            .HasMaxValue(50)
            .ToDomainResult();
        
        return result.IsError
            ? ErrorDomainResult<Name>.Create(result.ErrorMessages)
            : SuccessDomainResult<Name>.Create(new Name(name));
    }
}