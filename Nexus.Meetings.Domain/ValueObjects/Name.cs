using Nexus.Shared.Domain.Guards;
using Nexus.Shared.Domain.Result;
using Nexus.Shared.Domain.ValueObjects.Base;

namespace Nexus.Meetings.Domain.ValueObjects;

public record Name : ValueObject
{
    public string Value { get; private set; }

    private Name(string name)
    {
        Value = name;
    }

    public static DomainResult<Name> Create(string name)
    {
        var result = StringGuard.Create(name)
            .NotNullAndEmpty()
            .HasMaxValue(50)
            .ToDomainResult();
        return result
            ? DomainResult<Name>.Error(result)
            : DomainResult<Name>.Success(new Name(name));
    }
}