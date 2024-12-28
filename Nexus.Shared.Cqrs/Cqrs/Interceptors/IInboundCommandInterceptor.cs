using Nexus.Shared.Domain.Result;

namespace Nexus.Shared.Mediator.Cqrs.Interceptors;

public interface IInboundCommandInterceptor<TCommand> where TCommand : ICommand
{
    byte Order { get; }
    ValueTask<IResult<TCommand>> Handle(TCommand command, CancellationToken token);
}