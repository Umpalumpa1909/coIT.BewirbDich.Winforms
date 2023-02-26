using MediatR;

namespace coIT.BewirbDich.Domain.Entities;

public interface IDomainEvent : INotification
{
    public Guid Id { get; init; }
}