using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;
using Nexus.Shared.Cqrs.Dispatcher;
using Nexus.Shared.Cqrs.Interfaces;
using Nexus.Shared.Domain.Result;

namespace Nexus.Shared.Endpoints;

public abstract class PostEndpoint<TCommand, TCommandResult> : Endpoint
    where TCommand : ICommand<IResult<TCommandResult>> where TCommandResult : ICommandResult
{
    public static void MapCommandPost(IEndpointRouteBuilder app, string route)
    {
        app.MapPost(route,
            async (TCommand command, ICommandDispatcher dispatcher, CancellationToken token) =>
                await dispatcher.Dispatch<TCommand, TCommandResult>(command, token));
    }
}