using Nexus.Shared.Domain.Result;

namespace Nexus.Shared.Mediator.Cqrs.Interceptors;

public interface ICommandInterceptor
{
    ValueTask<IResult<TCommandResult>> Dispatch<TCommand, TCommandResult>(TCommand command)
        where TCommand : ICommand<IResult<TCommandResult>> where TCommandResult : ICommandResult;
}