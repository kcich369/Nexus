using Nexus.Shared.Domain.Results.Abstractions;

namespace Nexus.Shared.Domain.Results;

public sealed class NotFoundResult<T> : ErrorResult<T>
{
    private NotFoundResult(IEnumerable<string> errors) : base(errors)
    {
    }

    public static NotFoundResult<T> Create(string error) => Create([error]);
    public static NotFoundResult<T> Create(IEnumerable<string> error) => new(error);

    public override IResult<TResult> MapToResult<TResult>(TResult data) =>
        NotFoundResult<TResult>.Create(ErrorMessages);
}