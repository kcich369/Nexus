using Microsoft.Extensions.DependencyInjection;
using Nexus.Shared.Cqrs.Interfaces;
using Nexus.Shared.Domain.Result;

namespace Nexus.Shared.Cqrs.Resolvers;

internal class HandlersResolver(IServiceProvider serviceProvider)
{
    public ICommandHandler<TCommand, TCommandResult> GetCommandHandler<TCommand, TCommandResult>()
        where TCommand : ICommand<TCommandResult> where TCommandResult : ICommandResult =>
        serviceProvider.GetRequiredService<ICommandHandler<TCommand, TCommandResult>>();
    
    public IQueryHandler<TQuery, TQueryResult> GetQueryHandler<TQuery, TQueryResult>()
        where TQuery : IQuery<TQueryResult> where TQueryResult : IQueryResult =>
        serviceProvider.GetRequiredService<IQueryHandler<TQuery, TQueryResult>>();
}