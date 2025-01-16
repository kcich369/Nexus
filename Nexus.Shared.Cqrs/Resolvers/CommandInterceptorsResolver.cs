using Microsoft.Extensions.DependencyInjection;
using Nexus.Shared.Cqrs.Interceptors;
using Nexus.Shared.Cqrs.Interfaces;

namespace Nexus.Shared.Cqrs.Resolvers;

internal class CommandInterceptorsResolver(IServiceProvider serviceProvider)
{
    public IReadOnlyCollection<IInboundCommandInterceptor<TCommand>> InboundInterceptors<TCommand>()
        where TCommand : ICommand =>
        serviceProvider.GetServices<IInboundCommandInterceptor<TCommand>>()
            .OrderBy(x => x.Order)
            .ToList()
            .AsReadOnly();

    public IReadOnlyCollection<IOutboundCommandInterceptor<TCommand, TResult>> OutboundInterceptors<TCommand, TResult>()
        where TCommand : ICommand<TResult> where TResult : ICommandResult =>
        serviceProvider.GetServices<IOutboundCommandInterceptor<TCommand, TResult>>()
            .OrderBy(x => x.Order)
            .ToList()
            .AsReadOnly();
}