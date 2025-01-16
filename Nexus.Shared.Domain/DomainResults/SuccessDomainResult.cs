using Nexus.Shared.Domain.DomainResults.Abstractions;

namespace Nexus.Shared.Domain.DomainResults;

public sealed class SuccessDomainResult<T> : IDomainResult<T>
{
    public bool IsError => false;
    public IEnumerable<string> ErrorMessages { get; } = [];
    public T Data { get; } = default;


    private SuccessDomainResult(T data)
    {
        Data = data;
    }
    
    public static SuccessDomainResult<T> Create(T data) => new(data);
    
    public IDomainResult<TResult> MapToResult<TResult>(TResult data)
    {
        return SuccessDomainResult<TResult>.Create(data);
    }
}