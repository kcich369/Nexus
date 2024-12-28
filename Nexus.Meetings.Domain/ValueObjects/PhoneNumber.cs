using Nexus.Shared.Domain.Guards;
using Nexus.Shared.Domain.Result;
using Nexus.Shared.Domain.ValueObjects.Base;

namespace Nexus.Meetings.Domain.ValueObjects;

public sealed record PhoneNumber : ValueObject
{
    public string Prefix { get; private set; }
    public string Value { get; private set; }

    private PhoneNumber(string surname)
    {
        Value = surname;
    }

    public static DomainResult<PhoneNumber> Create(string phoneNumber, string prefix)
    {
        var result = StringGuard.Create(phoneNumber)
            .HasMaxValue(9)
            .IsPhoneNumber()
            .IsPhonePrefix(prefix)
            .ToDomainResult();

        return result
            ? DomainResult<PhoneNumber>.Error(result)
            : DomainResult<PhoneNumber>.Success(new PhoneNumber(phoneNumber));
    }

    public string GetFullValue() => $"{Prefix}{Value}";
}