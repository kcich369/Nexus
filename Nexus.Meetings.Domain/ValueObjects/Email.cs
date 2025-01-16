using Nexus.Shared.Domain.DomainResults;
using Nexus.Shared.Domain.DomainResults.Abstractions;
using Nexus.Shared.Domain.Guards;
using Nexus.Shared.Domain.Results;
using Nexus.Shared.Domain.ValueObjects.Base;

namespace Nexus.Meetings.Domain.ValueObjects;

public record Email : ValueObject
{
    public string Value { get; private set; }

    private Email(string surname)
    {
        Value = surname;
    }

    public static IDomainResult<Email> Create(string email)
    {
        var result = StringGuard.Create(email)
            .HasMaxValue(100)
            .IsEmail()
            .ToDomainResult();
        return result.MapToResult(new Email(email));
    }
}