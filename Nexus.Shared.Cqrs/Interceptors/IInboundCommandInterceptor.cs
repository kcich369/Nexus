using Nexus.Shared.Cqrs.Interfaces;

namespace Nexus.Shared.Cqrs.Interceptors;

public interface IInboundCommandInterceptor<in TCommand> where TCommand : ICommand
{
    byte Order { get; }
    ValueTask<bool> Handle(TCommand command, CancellationToken token);
}