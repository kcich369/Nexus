using Microsoft.Extensions.DependencyInjection;
using Nexus.Shared.Mediator.Cqrs.Interceptors;

namespace Nexus.Shared.Mediator.Cqrs.Resolvers;

internal class CommandInterceptorsResolver(IServiceProvider serviceProvider)
{
    public IReadOnlyCollection<IInboundCommandInterceptor<TCommand>> InboundInterceptors<TCommand>()
        where TCommand : ICommand =>
        serviceProvider.GetServices<IInboundCommandInterceptor<TCommand>>()
            .OrderBy(x => x.Order)
            .ToList()
            .AsReadOnly();

    public IReadOnlyCollection<IOutboundCommandInterceptor<TResult>> OutboundInterceptors<TResult>()
        where TResult : ICommandResult =>
        serviceProvider.GetServices<IOutboundCommandInterceptor<TResult>>()
            .OrderBy(x => x.Order)
            .ToList()
            .AsReadOnly();
}