using Nexus.Shared.Domain.Result;

namespace Nexus.Shared.Mediator.Cqrs.Interceptors;

public interface IOutboundQueryInterceptor<in TQuery, TResult> 
    where TQuery : IQuery<IResult<TResult>> where TResult : IQueryResult
{
    byte Order { get; }
    ValueTask<IResult<TResult>> Handle(TQuery command, CancellationToken token);
}