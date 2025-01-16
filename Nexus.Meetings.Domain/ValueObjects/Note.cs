using Nexus.Shared.Domain.DomainResults;
using Nexus.Shared.Domain.DomainResults.Abstractions;
using Nexus.Shared.Domain.Guards;
using Nexus.Shared.Domain.Results;
using Nexus.Shared.Domain.ValueObjects.Base;

namespace Nexus.Meetings.Domain.ValueObjects;

public sealed record Note : ValueObject
{
    public string Value { get; private set; }

    private Note(string note)
    {
        Value = note;
    }

    public static IDomainResult<Note> Create(string note)
    {
        var result = StringGuard.Create(note)
            .HasMaxValue(1000)
            .ToDomainResult();
        return result.MapToResult(new Note(note));
    }
}