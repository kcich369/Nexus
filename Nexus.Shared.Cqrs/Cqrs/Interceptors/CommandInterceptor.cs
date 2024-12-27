using Nexus.Shared.Domain.Result;
using Nexus.Shared.Mediator.Cqrs.Dispatcher;

namespace Nexus.Shared.Mediator.Cqrs.Interceptors;

public abstract class CommandInterceptor(ICommandDispatcher commandDispatcher) :ICommandInterceptor
{
    public async ValueTask<IResult<TCommandResult>> Dispatch<TCommand, TCommandResult>(TCommand command)
        where TCommand : ICommand<IResult<TCommandResult>> where TCommandResult : ICommandResult
    {
        var result = await DispatchCommand(command, commandDispatcher.Dispatch<TCommand, TCommandResult>(command));
        return result;
    }

    protected abstract ValueTask<IResult<TCommandResult>> DispatchCommand<TCommand, TCommandResult>(TCommand command, ValueTask<IResult<TCommandResult>> task)
        where TCommand : ICommand<IResult<TCommandResult>> where TCommandResult : ICommandResult;
}