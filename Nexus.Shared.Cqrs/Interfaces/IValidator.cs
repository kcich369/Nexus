using Nexus.Shared.Domain.Result;

namespace Nexus.Shared.Cqrs.Interfaces;

public interface ICommandValidator<TRequest, TResult> 
    where TRequest : ICommand<TResult> where TResult : ICommandResult
{
    ValueTask<IResult<TRequest>> Validate(TRequest command, CancellationToken token);
}