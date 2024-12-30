using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;
using Nexus.Shared.Cqrs.Dispatcher;
using Nexus.Shared.Cqrs.Interfaces;
using Nexus.Shared.Endpoints.Routes;

namespace Nexus.Shared.Endpoints;

public class PostEndpoint<TCommand, TCommandResult> : Endpoint
    where TCommand : ICommand<TCommandResult> where TCommandResult : ICommandResult
{
    protected PostEndpoint(ApiEndpointRoute endpointRoute) : base(endpointRoute)
    {
    }

    protected override void Map(IEndpointRouteBuilder app)
    {
        app.MapPost(Route,
            async (TCommand command, ICommandDispatcher dispatcher, CancellationToken token) =>
                await dispatcher.Dispatch<TCommand, TCommandResult>(command, token));
    }
}