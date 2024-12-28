using Nexus.Shared.Domain.Result;

namespace Nexus.Shared.Mediator.Cqrs.Interceptors;

public interface IInboundQueryInterceptor<TQuery> 
    where TQuery : IQuery
{
    byte Order { get; }
    ValueTask<IResult<TQuery>> Handle(TQuery command, CancellationToken token);
}