using Nexus.Shared.Domain.Guards;
using Nexus.Shared.Domain.Result;
using Nexus.Shared.Domain.ValueObjects.Base;

namespace Nexus.Meetings.Domain.ValueObjects;

public record Email : ValueObject
{
    public string Value { get; private set; }

    private Email(string surname)
    {
        Value = surname;
    }

    public static DomainResult<Email> Create(string email)
    {
        var result = StringGuard.Create(email)
            .HasMaxValue(100)
            .IsEmail()
            .ToDomainResult();
        return result
            ? DomainResult<Email>.Error(result)
            : DomainResult<Email>.Success(new Email(email));
    }
}