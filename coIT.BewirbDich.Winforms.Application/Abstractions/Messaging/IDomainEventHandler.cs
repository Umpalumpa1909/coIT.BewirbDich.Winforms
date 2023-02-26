using coIT.BewirbDich.Winforms.Domain.Entities;
using MediatR;

namespace coIT.BewirbDich.Winforms.Application.Abstractions.Messaging;

public interface IDomainEventHandler<TEvent> : INotificationHandler<TEvent>
    where TEvent : IDomainEvent
{
}