namespace Nexus.Shared.Domain.Result;

public interface IResult
{
    public IEnumerable<string> ErrorMessages { get; }
    public bool IsError { get; }
}

public interface IResult<out T> : IResult
{
    public T Data { get; }
}