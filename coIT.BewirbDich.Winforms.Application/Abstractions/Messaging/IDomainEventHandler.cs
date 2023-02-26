using coIT.BewirbDich.Domain.Entities;
using MediatR;

namespace coIT.BewirbDich.Application.Abstractions.Messaging;

public interface IDomainEventHandler<TEvent> : INotificationHandler<TEvent>
    where TEvent : IDomainEvent
{
}