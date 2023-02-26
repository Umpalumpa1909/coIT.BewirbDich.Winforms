using coIT.BewirbDich.Winforms.Domain.Entities;

namespace coIT.BewirbDich.Winforms.Domain.DomainEvents;

public abstract record DomainEvent(Guid Id) : IDomainEvent;