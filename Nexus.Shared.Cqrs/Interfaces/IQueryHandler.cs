using Nexus.Shared.Domain.Results.Abstractions;

namespace Nexus.Shared.Cqrs.Interfaces;

public interface IQueryHandler<in TQuery, TResult> 
    where TQuery : IQuery<TResult> where TResult : IQueryResult
{
    ValueTask<IResult<TResult>> Handle(TQuery command, CancellationToken token);
}