using Nexus.Shared.Domain.Result;

namespace Nexus.Shared.Mediator.Cqrs;

public interface ICommandHandler<in TRequest, TResult> 
    where TRequest : ICommand<IResult<TResult>> where TResult : ICommandResult
{
    ValueTask<IResult<TResult>> Handle(TRequest command);
}

