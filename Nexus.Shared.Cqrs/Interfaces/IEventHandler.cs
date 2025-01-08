using Nexus.Shared.Domain.Events;

namespace Nexus.Shared.Cqrs.Interfaces;

public interface IEventHandler<in TEvent> where TEvent : IDomainEvent
{
    Task<bool> Publish(TEvent @event, CancellationToken token);
}