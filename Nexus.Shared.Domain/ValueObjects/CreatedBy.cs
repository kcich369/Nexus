using Nexus.Shared.Domain.Guards;
using Nexus.Shared.Domain.Result;
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

    public static DomainResult<CreatedBy> Create(string userName)
    {
        var result = StringGuard.Create(userName)
            .HasMaxValue(50)
            .NotNullAndEmpty()
            .ToDomainResult();
        return result
            ? DomainResult<CreatedBy>.Error(result)
            : DomainResult<CreatedBy>.Success(new(userName));
    }
}