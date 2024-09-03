using Nexus.Shared.Domain.Guards;
using Nexus.Shared.Domain.Result;
using Nexus.Shared.Domain.ValueObjects.Base;

namespace Nexus.Meetings.Domain.ValueObjects;

public sealed record Note : ValueObject
{
    public string Value { get; private set; }

    private Note(string note)
    {
        Value = note;
    }

    public static DomainResult<Note> Create(string note)
    {
        var result = StringGuard.Create(note)
            .HasMaxValue(1000)
            .ToDomainResult();
        return result
            ? DomainResult<Note>.Error(result)
            : DomainResult<Note>.Success(new Note(note));
    }
}