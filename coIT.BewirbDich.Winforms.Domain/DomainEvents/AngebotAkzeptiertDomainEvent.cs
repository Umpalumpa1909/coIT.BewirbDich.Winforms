namespace coIT.BewirbDich.Winforms.Domain.DomainEvents;

public sealed record AngebotAkzeptiertDomainEvent(
    Guid Id,
    Guid versicherungsVorgangId) : DomainEvent(Id);