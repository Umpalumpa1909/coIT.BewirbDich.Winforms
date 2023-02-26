using coIT.BewirbDich.Application.Abstractions.Messaging;

namespace coIT.BewirbDich.Application.VersicherungsVorgaenge.Commands;

public record VersicherungsscheinAustellenCommand(Guid Id) : ICommand;