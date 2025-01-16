using Microsoft.Extensions.DependencyInjection;
using Nexus.Shared.Cqrs.Interfaces;
using Nexus.Shared.Domain.Events;

namespace Nexus.Shared.Cqrs.Resolvers;

internal class EventHandlersResolver(IServiceProvider serviceProvider)
{
    public IEnumerable<IEventHandler<TEvent>> GetEventHandlers<TEvent>()
        where TEvent : IDomainEvent => serviceProvider.GetServices<IEventHandler<TEvent>>();
}