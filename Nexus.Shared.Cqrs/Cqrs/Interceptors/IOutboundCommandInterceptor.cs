using Nexus.Shared.Domain.Result;

namespace Nexus.Shared.Mediator.Cqrs.Interceptors;

public interface IOutboundCommandInterceptor<in TCommand, TResult> 
    where TCommand : ICommand<IResult<TResult>> where TResult : ICommandResult
{
    byte Order { get; }
    ValueTask<IResult<TResult>> Handle(TCommand command, CancellationToken token);
}