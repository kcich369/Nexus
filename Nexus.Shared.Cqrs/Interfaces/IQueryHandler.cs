using Nexus.Shared.Domain.Result;

namespace Nexus.Shared.Cqrs.Interfaces;

public interface IQueryHandler<in TQuery, TResult> 
    where TQuery : IQuery<IResult<TResult>> where TResult : IQueryResult
{
    ValueTask<IResult<TResult>> Handle(TQuery command, CancellationToken token);
}