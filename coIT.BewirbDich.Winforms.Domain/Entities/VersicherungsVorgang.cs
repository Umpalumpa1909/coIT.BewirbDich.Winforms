using coIT.BewirbDich.Domain.DomainEvents;
using coIT.BewirbDich.Domain.Enums;
using coIT.BewirbDich.Domain.Errors;
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

    public BerechungsParameter BerechungsParameter { get; private set; }
    public DateTime Erstellungsdatum { get; private set; }
    public VersicherungsKonditionen VersicherungsKonditionen { get; private set; }
    public Versicherungsschein? Versicherungsschein { get; private set; } = null;
    public VorgangsStatus VorgangsStatus { get; private set; }

    public static Result<VersicherungsVorgang> Create(BerechungsParameter berechungsParameter)
    {
        var vorgang = new VersicherungsVorgang(Guid.NewGuid());

        vorgang.BerechungsParameter = berechungsParameter;
        var result = berechungsParameter.BerechneKonditionen();
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
                return Result.Failure(DomainErrors.VersicherungsVorgang.UnbekanntesCreditRating);
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
        return Result.Failure(DomainErrors.VersicherungsVorgang.VersicherungsVorgangStatusUngleichAngebot);
    }

    public Result VersicherungsscheinAustellen()
    {
        if (VorgangsStatus == VorgangsStatus.Auftragsbestaetigung)
        {
            Versicherungsschein = new Versicherungsschein(Guid.NewGuid());
            VorgangsStatus = VorgangsStatus.Lieferschein;
            return Result.Success();
        }

        return Result.Failure(DomainErrors.VersicherungsVorgang.VersicherungsVorgangStatusUngleichAuftragsbestätigung);
    }
}