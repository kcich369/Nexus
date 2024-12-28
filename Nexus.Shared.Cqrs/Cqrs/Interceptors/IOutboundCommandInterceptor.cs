using Nexus.Shared.Domain.Result;

namespace Nexus.Shared.Mediator.Cqrs.Interceptors;

public interface IOutboundCommandInterceptor<TResult> where TResult : ICommandResult
{
    byte Order { get; }
    ValueTask<IResult<TResult>> Handle(IResult<TResult> result, CancellationToken token);
}