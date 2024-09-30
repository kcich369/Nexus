using Microsoft.Extensions.DependencyInjection;
using Nexus.Shared.Domain.Result;

namespace Nexus.Shared.Mediator.Cqrs.Dispatcher;

internal class QueryDispatcher(IServiceProvider serviceProvider) : IQueryDispatcher
{
    public ValueTask<IResult<TQueryResult>> Dispatch<TQuery, TQueryResult>(TQuery query)
        where TQuery : IQuery<IResult<TQueryResult>> where TQueryResult : IQueryResult
    {
        var handler = serviceProvider.GetRequiredService<IQueryHandler<TQuery, TQueryResult>>();
        return handler.Handle(query);
    }
}