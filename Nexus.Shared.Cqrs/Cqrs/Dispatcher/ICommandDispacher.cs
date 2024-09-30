using Nexus.Shared.Domain.Result;

namespace Nexus.Shared.Mediator.Cqrs.Dispatcher;

public interface ICommandDispatcher
{
    ValueTask<IResult<TCommandResult>> Dispatch<TCommand, TCommandResult>(TCommand command)
        where TCommand : ICommand<IResult<TCommandResult>> where TCommandResult : ICommandResult;
}