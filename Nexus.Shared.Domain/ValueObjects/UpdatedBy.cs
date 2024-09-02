using Nexus.Shared.Domain.Guards;
using Nexus.Shared.Domain.Result;
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

    public static DomainResult<UpdatedBy> Create(string userName)
    {
        var result = StringGuard.Create(userName)
            .HasMaxValue(50)
            .NotNullAndEmpty()
            .ToDomainResult();
        return result
            ? DomainResult<UpdatedBy>.Error(result)
            : DomainResult<UpdatedBy>.Success(new(userName));
    }
}