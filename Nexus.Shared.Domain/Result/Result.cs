namespace Nexus.Shared.Domain.Result;

public class Result : IResult
{
    public IEnumerable<string> ErrorMessages { get; private set; } = null;
    public bool IsError { get; private set; }

    protected Result()
    {
    }

    protected Result(IEnumerable<string> errors)
    {
        ErrorMessages = errors;
        IsError = true;
    }

    protected Result(string error)
    {
        if (string.IsNullOrEmpty(error))
        {
            ErrorMessages = null;
            IsError = false;
        }

        ErrorMessages = [error];
        IsError = true;
    }

    public static implicit operator bool(Result result) => result.IsError;
}

public class Result<T> : Result, IResult<T>
{
    public T Data { get; private set; }

    private Result(T data) : base()
    {
        Data = data;
    }

    private Result(IEnumerable<string> errors) : base(errors)
    {
    }

    public static Result<T> Success(T data) => new(data);

    public static Result<T> Error(string error)
    {
        if (string.IsNullOrEmpty(error))
            error = "Error occured";
        return new([error]);
    }
    
    public static Result<T> Error(IEnumerable<string> errors)
    {
        return new(errors);
    }

    public static Result<T> Error(IResult result) => new(result.ErrorMessages);
}
