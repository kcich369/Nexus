namespace Nexus.Shared.Domain.Results.Abstractions;

public abstract class ErrorResult<T>(IEnumerable<string> errors) : IResult<T>
{
    public IEnumerable<string> ErrorMessages { get; private set; } = errors;
    public bool IsError { get; } = true;
    public T Data { get; private set; } = default;
    public abstract IResult<TResult> MapToResult<TResult>(TResult data);
}
