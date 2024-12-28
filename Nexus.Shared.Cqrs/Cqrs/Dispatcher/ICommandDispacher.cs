using Nexus.Shared.Domain.Result;

namespace Nexus.Shared.Mediator.Cqrs.Dispatcher;

public interface ICommandDispatcher
{
    ValueTask<IResult<TCommandResult>> Dispatch<TCommand, TCommandResult>(TCommand command, CancellationToken token)
        where TCommand : ICommand<IResult<TCommandResult>> where TCommandResult : ICommandResult;
}