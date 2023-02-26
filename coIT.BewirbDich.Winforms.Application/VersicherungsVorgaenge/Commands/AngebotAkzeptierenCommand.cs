using coIT.BewirbDich.Application.Abstractions.Messaging;

namespace coIT.BewirbDich.Application.VersicherungsVorgaenge.Commands;

public record AngebotAkzeptierenCommand(Guid Id) : ICommand;