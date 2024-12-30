using Nexus.Shared.Domain.Result;

namespace Nexus.Shared.Cqrs.Interfaces;

public interface ICommandValidator<in TRequest, TResult> 
    where TRequest : ICommand<TResult> where TResult : ICommandResult
{
    ValueTask<IResult<TResult>> Validate(TRequest command, CancellationToken token);
}