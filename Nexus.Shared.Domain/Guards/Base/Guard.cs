using Nexus.Shared.Domain.DomainResults;
using Nexus.Shared.Domain.DomainResults.Abstractions;

namespace Nexus.Shared.Domain.Guards.Base;

public abstract class Guard<T>(T value, string errorPrefix)
{
    private readonly List<string> _errors = new();
    protected T Value { get; } = value;

    private string AddErrorPrefix(string error) =>
        string.IsNullOrEmpty(errorPrefix) ? error : $"{errorPrefix}.{error}";

    protected void AddError(string error) => _errors.Add(AddErrorPrefix(error));

    public IDomainResult<T> ToDomainResult() =>
        _errors.Count != 0 ? ErrorDomainResult<T>.Create(_errors) : SuccessDomainResult<T>.Create(Value);
}