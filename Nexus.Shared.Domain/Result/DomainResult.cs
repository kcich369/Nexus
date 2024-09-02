namespace Nexus.Shared.Domain.Result;

public class DomainResult
{
    public IEnumerable<string> ErrorMessages { get; private set; } = null;
    public bool IsError { get; private set; }

    protected DomainResult()
    {
    }

    protected DomainResult(IEnumerable<string> errors)
    {
        ErrorMessages = errors;
        IsError = true;
    }

    protected DomainResult(string error)
    {
        if (string.IsNullOrEmpty(error))
        {
            ErrorMessages = null;
            IsError = false;
        }

        ErrorMessages = [error];
        IsError = true;
    }

    public static DomainResult HaveErrors(params DomainResult[] results)
    {
        var errors = results.Where(x => x.IsError)
            .SelectMany(x => x.ErrorMessages)
            .ToArray();
        return errors.Length != 0
            ? new DomainResult(errors)
            : new DomainResult();
    }

    public static implicit operator bool(DomainResult result) => result.IsError;
}

public class DomainResult<T> : DomainResult
{
    public T Data { get; private set; }

    private DomainResult(T data) : base()
    {
        Data = data;
    }

    private DomainResult(IEnumerable<string> errors) : base(errors)
    {
    }

    public static DomainResult<T> Success(T data) => new(data);

    public static DomainResult<T> Error(string error)
    {
        if (string.IsNullOrEmpty(error))
            error = "Error occured";
        return new([error]);
    }
    
    public static DomainResult<T> Error(IEnumerable<string> errors)
    {
        return new(errors);
    }

    public static DomainResult<T> Error(DomainResult result) => new(result.ErrorMessages);
}