using Nexus.Shared.Domain.Result;

namespace Nexus.Shared.Mediator.Cqrs;

public interface IQueryHandler<in TRequest, TResult> 
    where TRequest : IQuery<IResult<TResult>> where TResult : IQueryResult
{
    ValueTask<IResult<TResult>> Handle(TRequest command);
}