using Nexus.Shared.Domain.Results.Abstractions;

namespace Nexus.Shared.Domain.Results;

public sealed class OkResult<T> : SuccessResult<T>
{
    private OkResult(T data) : base(data)
    {
    }

    public static IResult<T> Create(T data) => new OkResult<T>(data);

    public override IResult<TResult> MapToResult<TResult>(TResult data) => OkResult<TResult>.Create(data);
}