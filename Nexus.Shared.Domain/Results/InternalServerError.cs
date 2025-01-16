using Nexus.Shared.Domain.Results.Abstractions;

namespace Nexus.Shared.Domain.Results;

public class InternalServerError<T> : ErrorResult<T>
{
    private InternalServerError(IEnumerable<string> errors) : base(errors)
    {
    }

    public static InternalServerError<T> Create(string error) => Create([error]);
    public static InternalServerError<T> Create(IEnumerable<string> error) => new(error);

    public override IResult<TResult> MapToResult<TResult>(TResult data) =>
        InternalServerError<TResult>.Create(ErrorMessages);
}