using Nexus.Shared.Cqrs.Interfaces;
using Nexus.Shared.Domain.Results.Abstractions;

namespace Nexus.Shared.Cqrs.Interceptors;

public interface IOutboundCommandInterceptor<in TCommand, in TResult>
    where TCommand : ICommand<TResult> where TResult : ICommandResult
{
    byte Order { get; }
    ValueTask<bool> Handle(TCommand command, IResult<TResult> result, CancellationToken token);
}