using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;
using Nexus.Shared.Cqrs.Dispatcher;
using Nexus.Shared.Cqrs.Interfaces;
using Nexus.Shared.Endpoints.Abstractions;
using Nexus.Shared.Endpoints.Routes;

namespace Nexus.Shared.Endpoints.Api;

public abstract class GetEndpoint<TQuery, TQueryResult>(ApiEndpointRoute endpointRoute) : Endpoint(endpointRoute)
    where TQuery : IQuery<TQueryResult>
    where TQueryResult : IQueryResult
{
    protected override void Map(IEndpointRouteBuilder app)
    {
        app.MapPost(Route,
            async (TQuery query, IQueryDispatcher dispatcher, CancellationToken token) =>
                await dispatcher.Dispatch<TQuery, TQueryResult>(query, token));
    }
}