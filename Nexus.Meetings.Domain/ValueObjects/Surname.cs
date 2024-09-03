using Nexus.Shared.Domain.Guards;
using Nexus.Shared.Domain.Result;
using Nexus.Shared.Domain.ValueObjects.Base;

namespace Nexus.Meetings.Domain.ValueObjects;

public record Surname : ValueObject
{
    public string Value { get; private set; }

    private Surname(string surname)
    {
        Value = surname;
    }

    public static DomainResult<Surname> Create(string surname)
    {
        var result = StringGuard.Create(surname)
            .NotNullAndEmpty()
            .HasMaxValue(50)
            .ToDomainResult();
        return result
            ? DomainResult<Surname>.Error(result)
            : DomainResult<Surname>.Success(new Surname(surname));
    }
}