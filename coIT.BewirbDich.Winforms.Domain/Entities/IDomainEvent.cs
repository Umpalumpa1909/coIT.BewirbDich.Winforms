using MediatR;

namespace coIT.BewirbDich.Winforms.Domain.Entities;

public interface IDomainEvent : INotification
{
    public Guid Id { get; init; }
}