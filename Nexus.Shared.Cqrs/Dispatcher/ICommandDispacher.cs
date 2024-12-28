using Nexus.Shared.Cqrs.Interfaces;
using Nexus.Shared.Domain.Result;
using Nexus.Shared.Mediator.Cqrs;

namespace Nexus.Shared.Cqrs.Dispatcher;

public interface ICommandDispatcher
{
    ValueTask<IResult<TCommandResult>> Dispatch<TCommand, TCommandResult>(TCommand command, CancellationToken token)
        where TCommand : ICommand<IResult<TCommandResult>> where TCommandResult : ICommandResult;
}