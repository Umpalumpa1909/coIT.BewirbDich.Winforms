using coIT.BewirbDich.Application.Abstractions.Messaging;

namespace coIT.BewirbDich.Application.VersicherungsVorgaenge.Commands;

public record VersicherungsVorgangLoeschenCommand(Guid Id) : ICommand;