using Nexus.Shared.Domain.Guards;
using Nexus.Shared.Domain.Result;
using Nexus.Shared.Domain.ValueObjects.Base;

namespace Nexus.Meetings.Domain.ValueObjects;

public record Duration : ValueObject
{
    public DateTimeOffset From { get; private set; }
    public DateTimeOffset To { get; private set; }

    private Duration(DateTimeOffset from, DateTimeOffset to)
    {
        From = from;
        To = to;
    }

    public static DomainResult<Duration> Create(DateTimeOffset from, DateTimeOffset to)
    {
        var result = DateTimeGuard.Create(from.DateTime).Before(to.DateTime)
            .MaxDiffInHours(to.DateTime, 3)
            .ToDomainResult();
        return result
            ? DomainResult<Duration>.Error(result)
            : DomainResult<Duration>.Success(new(from, to));
    }
}