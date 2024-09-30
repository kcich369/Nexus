using Nexus.Shared.Domain.Result;

namespace Nexus.Shared.Mediator.Cqrs.Dispatcher;

internal sealed class LoggingDispatcherDecorator( ICommandDispatcher commandDispatcher): ICommandDispatcher
{
    public async ValueTask<IResult<TCommandResult>> Dispatch<TCommand, TCommandResult>(TCommand command) where TCommand : ICommand<IResult<TCommandResult>> where TCommandResult : ICommandResult
    {
        //before
        var result = await commandDispatcher.Dispatch<TCommand, TCommandResult>(command);
        //after

        return result;
    }
}