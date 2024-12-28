using Microsoft.Extensions.DependencyInjection;
using Nexus.Shared.Cqrs.Interfaces;
using Nexus.Shared.Domain.Result;

namespace Nexus.Shared.Cqrs.Resolvers;

internal class HandlersResolver(IServiceProvider serviceProvider)
{
    public ICommandHandler<TCommand, TCommandResult> GetHandler<TCommand, TCommandResult>()
        where TCommand : ICommand<IResult<TCommandResult>> where TCommandResult : ICommandResult =>
        serviceProvider.GetRequiredService<ICommandHandler<TCommand, TCommandResult>>();
}