using Nexus.Shared.Domain.DomainResults.Abstractions;

namespace Nexus.Shared.Domain.DomainResults;

public sealed class ErrorDomainResult<T> : IDomainResult<T>
{
    public bool IsError { get; } = true;
    public IEnumerable<string> ErrorMessages { get; }
    public T Data { get; } = default;


    private ErrorDomainResult(IEnumerable<string> errors)
    {
        ErrorMessages = errors;
    }

    public static ErrorDomainResult<T> Create(string error) =>
        new ErrorDomainResult<T>([error]);
    
    public static ErrorDomainResult<T> Create(IEnumerable<string> errors) =>
        new ErrorDomainResult<T>(errors);
    
    public IDomainResult<TResult> MapToResult<TResult>(TResult data)
    {
       return ErrorDomainResult<TResult>.Create(ErrorMessages);
    }
}