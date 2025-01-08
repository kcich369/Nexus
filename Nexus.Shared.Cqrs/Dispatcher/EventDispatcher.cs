using Nexus.Shared.Cqrs.Resolvers;
using Nexus.Shared.Domain.Events;

namespace Nexus.Shared.Cqrs.Dispatcher;

internal class EventDispatcher(EventHandlersResolver eventHandlersResolver) : IEventDispatcher
{
    public async Task<bool> Dispatch<TEvent>(TEvent @event, CancellationToken token) where TEvent : IDomainEvent
    {
        await Task.WhenAll(eventHandlersResolver.GetEventHandlers<TEvent>().Select(x => x.Publish(@event, token)));
        return true;
    }
}