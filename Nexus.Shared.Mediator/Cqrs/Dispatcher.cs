using MediatR;
using Nexus.Shared.Domain.Result;

namespace Nexus.Shared.Mediator.Cqrs;

public interface IDispatcher
{
    ValueTask<IResult<TQuery>> HandleQuery<TQuery, TQueryResult>(TQuery command)
        where TQuery : ICommand<TQueryResult> where TQueryResult : ICommandResult;

    ValueTask<IResult<TCommandResult>> HandleCommand<TCommand, TCommandResult>(TCommand command)
        where TCommand : ICommand<TCommandResult> where TCommandResult : ICommandResult;
}

internal sealed class Dispatcher(IMediator mediator) : IDispatcher
{
    public async ValueTask<IResult<TQuery>> HandleQuery<TQuery, TQueryResult>(TQuery command) where TQuery : ICommand<TQueryResult> where TQueryResult : ICommandResult
    {
        var a = await mediator.Send(command);
        return mediator.Send(command);
    }

    public ValueTask<IResult<TCommandResult>> HandleCommand<TCommand, TCommandResult>(TCommand command) where TCommand : ICommand<TCommandResult> where TCommandResult : ICommandResult
    {
        throw new NotImplementedException();
    }
}