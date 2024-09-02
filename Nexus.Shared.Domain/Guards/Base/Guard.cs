using Nexus.Shared.Domain.Result;

namespace Nexus.Shared.Domain.Guards.Base;

public abstract class Guard(string errorPrefix)
{
    private readonly List<string> _errors = new();

    private  string AddErrorPrefix(string error) =>
        string.IsNullOrEmpty(errorPrefix) ? error : $"{errorPrefix}.{error}";

    protected void AddError(string error) => _errors.Add(AddErrorPrefix(error));

    public DomainResult<Guard> ToDomainResult() =>
        _errors.Count != 0 ? DomainResult<Guard>.Error(_errors) : DomainResult<Guard>.Success(this);
}