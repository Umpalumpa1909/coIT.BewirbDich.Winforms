using coIT.BewirbDich.Application.Abstractions.Messaging;
using coIT.BewirbDich.Domain.Enums;

namespace coIT.BewirbDich.Application.VersicherungsVorgaenge.Commands;

public record CreateVersicherungsVorgangCommand(decimal Versicherungssumme,
                               Zusatzschutz Zusatzschutz,
                               bool HatWebshop,
                               int AnzahlMitarbeiter,
                               Risiko Risiko,
                               Berechnungsart Berechnungsart) : ICommand<Guid>;