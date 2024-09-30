using Nexus.Shared.Domain.Result;

namespace Nexus.Shared.Mediator.Cqrs.Dispatcher;

public interface IQueryDispatcher
{
    ValueTask<IResult<TQueryResult>> Dispatch<TQuery, TQueryResult>(TQuery query)
        where TQuery : IQuery<IResult<TQueryResult>> where TQueryResult : IQueryResult;
}