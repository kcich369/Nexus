using Nexus.Shared.Cqrs.Interfaces;
using Nexus.Shared.Domain.Result;

namespace Nexus.Shared.Cqrs.Dispatcher;

public interface ICommandDispatcher
{
    ValueTask<IResult<TCommandResult>> Dispatch<TCommand, TCommandResult>(TCommand command, CancellationToken token)
        where TCommand : ICommand<TCommandResult> where TCommandResult : ICommandResult;
}