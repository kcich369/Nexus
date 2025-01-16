namespace Nexus.Shared.Domain.Results.Abstractions;

public interface IResult<out T>
{
    public bool IsError { get; }
    IEnumerable<string> ErrorMessages { get; }
    public T Data { get; }

    IResult<TResult> MapToResult<TResult>(TResult data);
}