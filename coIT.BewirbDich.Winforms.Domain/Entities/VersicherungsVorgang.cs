using coIT.BewirbDich.Domain.DomainEvents;
using coIT.BewirbDich.Domain.Enums;
using coIT.BewirbDich.Domain.Shared;

namespace coIT.BewirbDich.Domain.Entities;

public class VersicherungsVorgang : AggregateRoot
{
    private VersicherungsVorgang(Guid id) :
        base(id)
    {
        VorgangsStatus = VorgangsStatus.Angebot;
        Erstellungsdatum = DateTime.Now;
    }

    public Angebotsanfrage Angebotsanfrage { get; private set; }
    public DateTime Erstellungsdatum { get; private set; }
    public VersicherungsKonditionen VersicherungsKonditionen { get; private set; }
    public Versicherungsschein? Versicherungsschein { get; private set; } = null;
    public VorgangsStatus VorgangsStatus { get; private set; }

    public static Result<VersicherungsVorgang> Create(Angebotsanfrage angebotsanfrage)
    {
        var vorgang = new VersicherungsVorgang(Guid.NewGuid());

        vorgang.Angebotsanfrage = angebotsanfrage;
        var result = angebotsanfrage.BerechneKonditionen();
        if (result.IsSuccess)
        {
            vorgang.VersicherungsKonditionen = result.Value;
            return vorgang;
        }
        return Result.Failure<VersicherungsVorgang>(result.Error);
    }

    public Result AngebotAnnehmen(CreditRating creditRating)
    {
        switch (creditRating)
        {
            case CreditRating.high:
                VorgangsStatus = VorgangsStatus.Auftragsbestaetigung;
                break;

            case CreditRating.low:
                VorgangsStatus = VorgangsStatus.Abgelehnt;
                break;

            default:
                return Result.Failure(new Error("VersicherungsVorgang.AngebotAnnehmen",
                    $"unbekanntes CreditRating {creditRating}"));
        }
        return Result.Success();
    }

    public Result BestellungAusloesen()
    {
        if (VorgangsStatus == VorgangsStatus.Angebot)
        {
            VorgangsStatus = VorgangsStatus.Bestellung;
            RaiseDomainEvent(new AngebotAkzeptiertDomainEvent(Guid.NewGuid(), Id));
            return Result.Success();
        }
        return Result.Failure(new Error("VersicherungsVorgang.BestellungAusloesen", "Nur für Angebote kann eine Bestellung ausgelöst werden"));
    }

    public Result VersicherungsscheinAustellen()
    {
        if (VorgangsStatus == VorgangsStatus.Auftragsbestaetigung)
        {
            Versicherungsschein = new Versicherungsschein(Guid.NewGuid());
            VorgangsStatus = VorgangsStatus.Lieferschein;
            return Result.Success();
        }

        return Result.Failure(new Error("VersicherungsVorgang.VersicherungsscheinAustellen",
            "nur für Versicherungsvorgänge mit Status Versicherungsschein kann ein Versicherungsschein ausgestellt werden"));
    }
}