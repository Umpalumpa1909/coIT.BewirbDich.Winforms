using coIT.BewirbDich.Domain.Entities;

namespace coIT.BewirbDich.Domain.DomainEvents;

public abstract record DomainEvent(Guid Id) : IDomainEvent;