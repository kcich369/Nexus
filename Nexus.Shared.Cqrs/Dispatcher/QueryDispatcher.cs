using Nexus.Shared.Cqrs.Interfaces;
using Nexus.Shared.Cqrs.Resolvers;
using Nexus.Shared.Domain.Result;

namespace Nexus.Shared.Cqrs.Dispatcher;

internal class QueryDispatcher(HandlersResolver handlersResolver,
    QueryInterceptorsResolver queryInterceptorsResolver) : IQueryDispatcher
{
    public async ValueTask<IResult<TQueryResult>> Dispatch<TQuery, TQueryResult>(TQuery query, CancellationToken token)
        where TQuery : IQuery<TQueryResult> where TQueryResult : IQueryResult
    {
        foreach (var inboundInterceptor in queryInterceptorsResolver.InboundInterceptors<TQuery>())
        {
            await inboundInterceptor.Handle(query, token);
        }
        
        var handler = handlersResolver.GetQueryHandler<TQuery, TQueryResult>();
        var result = await handler.Handle(query, token);
        
        foreach (var inboundInterceptor in queryInterceptorsResolver.OutboundInterceptors<TQueryResult>())
        {
            await inboundInterceptor.Handle(result, token);
        }
        return result;
    }
}