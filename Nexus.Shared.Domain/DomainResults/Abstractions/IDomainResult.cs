namespace Nexus.Shared.Domain.DomainResults.Abstractions;

public interface IDomainResult<out T>
{
    public bool IsError { get; }
    IEnumerable<string> ErrorMessages { get; }
    public T Data { get; }

    IDomainResult<TResult> MapToResult<TResult>(TResult data);
}