using coIT.BewirbDich.Winforms.Application.Abstractions.Messaging;
using coIT.BewirbDich.Winforms.Domain.Enums;
using MediatR;

namespace coIT.BewirbDich.Winforms.Application.VersicherungsVorgaenge.Commands;

public record CreateVersicherungsVorgangCommand(decimal Versicherungssumme,
                               bool InkludiereZusatzschutz,
                               decimal ZusatzschutzAufschlag,
                               bool HatWebshop,
                               int AnzahlMitarbeiter,
                               Risiko Risiko,
                               Berechnungsart Berechnungsart) : ICommand<Guid>;