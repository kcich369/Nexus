using Nexus.Shared.Domain.DomainResults;
using Nexus.Shared.Domain.DomainResults.Abstractions;
using Nexus.Shared.Domain.Guards;
using Nexus.Shared.Domain.Results;
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

    public static IDomainResult<PhoneNumber> Create(string phoneNumber, string prefix)
    {
        var result = StringGuard.Create(phoneNumber)
            .HasMaxValue(9)
            .IsPhoneNumber()
            .IsPhonePrefix(prefix)
            .ToDomainResult();

        return result.MapToResult(new PhoneNumber(phoneNumber));
    }

    public string GetFullValue() => $"{Prefix}{Value}";
}