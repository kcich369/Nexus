using Nexus.Shared.Cqrs.Interfaces;
using Nexus.Shared.Domain.Results.Abstractions;

namespace Nexus.Shared.Cqrs.Dispatcher;

public interface IQueryDispatcher
{
    ValueTask<IResult<TQueryResult>> Dispatch<TQuery, TQueryResult>(TQuery query, CancellationToken token)
        where TQuery : IQuery<TQueryResult> where TQueryResult : IQueryResult;
}