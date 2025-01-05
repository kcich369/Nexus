using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;
using Nexus.Shared.Cqrs.Dispatcher;
using Nexus.Shared.Cqrs.Interfaces;
using Nexus.Shared.Endpoints.Abstractions;
using Nexus.Shared.Endpoints.Routes;

namespace Nexus.Shared.Endpoints.Api;

public abstract class PostEndpoint<TCommand, TCommandResult>(ApiEndpointRoute endpointRoute) : Endpoint(endpointRoute)
    where TCommand : ICommand<TCommandResult>
    where TCommandResult : ICommandResult
{
    protected override void Map(IEndpointRouteBuilder app)
    {
        app.MapPost(Route,
            async (TCommand command, ICommandDispatcher dispatcher, CancellationToken token) =>
                await dispatcher.Dispatch<TCommand, TCommandResult>(command, token));
    }
}