using Nexus.Shared.Cqrs.Interfaces;
using Nexus.Shared.Domain.Result;
using Nexus.Shared.Mediator.Cqrs;

namespace Nexus.Shared.Cqrs.Interceptors;

public interface IInboundCommandInterceptor<TCommand> where TCommand : ICommand
{
    byte Order { get; }
    ValueTask<IResult<TCommand>> Handle(TCommand command, CancellationToken token);
}