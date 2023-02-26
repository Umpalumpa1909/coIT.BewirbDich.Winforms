namespace coIT.BewirbDich.Domain.DomainEvents;

public sealed record AngebotAkzeptiertDomainEvent(
    Guid Id,
    Guid versicherungsVorgangId) : DomainEvent(Id);