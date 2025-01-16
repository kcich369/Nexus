using Nexus.Shared.Domain.Results.Abstractions;

namespace Nexus.Shared.Domain.Results;

public sealed class BadRequestResult<T> : ErrorResult<T>
{
    private BadRequestResult(IEnumerable<string> errors) : base(errors)
    {
    }

    public static BadRequestResult<T> Create(string error) => Create([error]);
    public static BadRequestResult<T> Create(IEnumerable<string> error) => new(error);

    public override IResult<TResult> MapToResult<TResult>(TResult data) =>
        BadRequestResult<TResult>.Create(ErrorMessages);
}