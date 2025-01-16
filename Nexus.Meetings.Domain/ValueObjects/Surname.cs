using Nexus.Shared.Domain.DomainResults.Abstractions;
using Nexus.Shared.Domain.Guards;
using Nexus.Shared.Domain.ValueObjects.Base;

namespace Nexus.Meetings.Domain.ValueObjects;

public record Surname : ValueObject
{
    public string Value { get; private set; }

    private Surname(string surname)
    {
        Value = surname;
    }

    public static IDomainResult<Surname> Create(string surname)
    {
        var result = StringGuard.Create(surname)
            .NotNullAndEmpty()
            .HasMaxValue(50)
            .ToDomainResult();
        return result.MapToResult(new Surname(surname));
    }
}