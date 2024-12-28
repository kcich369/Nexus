using Nexus.Shared.Cqrs.Interfaces;
using Nexus.Shared.Domain.Result;
using Nexus.Shared.Mediator.Cqrs;

namespace Nexus.Shared.Cqrs.Interceptors;

public interface IInboundQueryInterceptor<TQuery> 
    where TQuery : IQuery
{
    byte Order { get; }
    ValueTask<IResult<TQuery>> Handle(TQuery command, CancellationToken token);
}