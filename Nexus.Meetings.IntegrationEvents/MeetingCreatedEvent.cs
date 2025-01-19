using Nexus.Shared.Domain.Events;

namespace Nexus.Meetings.IntegrationEvents;

public record MeetingCreatedEvent() : IIntegrationEvent;