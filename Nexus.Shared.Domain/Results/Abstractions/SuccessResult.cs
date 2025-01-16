namespace Nexus.Shared.Domain.Results.Abstractions;

public abstract class SuccessResult<T>(T data) : IResult<T>
{
    public T Data { get; private set; } = data;

    public IEnumerable<string> ErrorMessages { get; } = [];
    public bool IsError { get; } = false;

    public abstract IResult<TResult> MapToResult<TResult>(TResult data);
}