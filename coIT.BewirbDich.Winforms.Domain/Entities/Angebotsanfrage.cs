using coIT.BewirbDich.Winforms.Domain.Enums;
using coIT.BewirbDich.Winforms.Domain.Errors;
using coIT.BewirbDich.Winforms.Domain.Primitives;
using coIT.BewirbDich.Winforms.Domain.Shared;

namespace coIT.BewirbDich.Winforms.Domain.Entities;

public sealed class Angebotsanfrage : Entity
{
    public Angebotsanfrage(Guid id, decimal versicherungssumme,
                               bool inkludiereZusatzschutz,
                               decimal zusatzschutzAufschlag,
                               bool hatWebshop,
                               int anzahlMitarbeiter,
                               Risiko risiko,
                               Berechnungsart berechnungsart)
        : base(id)
    {
        Versicherungssumme = versicherungssumme;
        InkludiereZusatzschutz = inkludiereZusatzschutz;
        ZusatzschutzAufschlag = zusatzschutzAufschlag;
        HatWebshop = hatWebshop;
        Risiko = risiko;
        Berechnungsart = berechnungsart;
    }

    public int AnzahlMitarbeiter { get; set; }
    public decimal Versicherungssumme { get; private set; }
    public bool InkludiereZusatzschutz { get; private set; }
    public decimal ZusatzschutzAufschlag { get; private set; }

    //Gibt es nur bei Unternehmen, die nach Umsatz abgerechnet werden
    public bool HatWebshop { get; private set; }

    public Risiko Risiko { get; private set; }

    public Berechnungsart Berechnungsart { get; private set; }

    private Result Validiere()
    {
        switch (Berechnungsart)
        {
            case Berechnungsart.Umsatz:
                break;

            case Berechnungsart.Haushaltssumme:
                if (Risiko != Risiko.Mittel)
                {
                    return Result.Failure(new Error("Angebotsanfrage.Validiere",
                        "Versicherungsnehmer, die nach Haushaltssumme versichert werden (primär Vereine) stellen immer ein mittleres Risiko da"));
                }
                break;

            case Berechnungsart.AnzahlMitarbeiter:
                if (AnzahlMitarbeiter > 5)
                {
                    return Result.Failure(new Error("Angebotsanfrage.Validiere",
                        "Versicherungsnehmer, die nach Anzahl Mitarbeiter abgerechnet werden und mehr als 5 Mitarbeiter haben, können kein Lösegeld absichern"));
                }
                break;

            default:
                return Result.Failure(DomainErrors.Angebotsanfrage.ErstelleDokumentUnbekannteBerechnungsart);
        }
        return Result.Success();
    }

    public Result<VersicherungsKonditionen> BerechneKonditionen()
    {
        var result = Validiere();
        if (result.IsFailure)
        {
            return Result.Failure<VersicherungsKonditionen>(result.Error);
        }
        switch (Berechnungsart)
        {
            case Berechnungsart.Umsatz:

                return BerechneUmsatz();

            case Berechnungsart.Haushaltssumme:
                return BerechneHaushaltssumme();

            case Berechnungsart.AnzahlMitarbeiter:
                return BerechneAnzahlMitarbeiter();

            default:
                return Result.Failure<VersicherungsKonditionen>(DomainErrors.Angebotsanfrage.ErstelleDokumentUnbekannteBerechnungsart);
        }
    }

    private decimal BerechneWebShopAufschlag(decimal beitrag)
    {
        if (!HatWebshop)
            return 0m;
        switch (Berechnungsart)
        {
            case Berechnungsart.Umsatz:
                return beitrag;

            default:
                return 0m;
        }
    }

    private decimal BerechneZusatzschutzAufschlag(decimal beitrag)
    {
        if (InkludiereZusatzschutz)
        {
            // Hier bin ich mir nicht sicher ob die Berechnung verändert werden soll als Aufgabe
            // habe es so verändert das der Prozentwert genutzt wird.
            //return beitrag * 1.0m + this.ZusatzschutzAufschlag / 100.0m;
            return beitrag * this.ZusatzschutzAufschlag / 100.0m;
        }
        return 0m;
    }

    private decimal BerechneRisikoAuschlag(decimal beitrag)
    {
        switch (Berechnungsart)
        {
            case Berechnungsart.Umsatz:
            case Berechnungsart.Haushaltssumme:
                if (Risiko == Risiko.Mittel)
                {
                    return beitrag * 0.2m;
                }
                break;

            case Berechnungsart.AnzahlMitarbeiter:
                if (Risiko == Risiko.Mittel)
                {
                    return beitrag * 0.3m;
                }
                break;

            default:
                return 0m;
        }
        return 0m;
    }

    private VersicherungsKonditionen BerechneUmsatz()
    {
        var berechnungbasis = (decimal)Math.Pow((double)Versicherungssumme, 0.25d);
        decimal beitrag = 1.1m * berechnungbasis;
        return ErstelleDokument(berechnungbasis, beitrag);
    }

    private VersicherungsKonditionen BerechneHaushaltssumme()
    {
        var berechnungbasis = (decimal)Math.Log10((double)this.Versicherungssumme);
        var beitrag = 1.0m * berechnungbasis + 100m;
        return ErstelleDokument(berechnungbasis, beitrag);
    }

    private VersicherungsKonditionen BerechneAnzahlMitarbeiter()
    {
        decimal beitrag;
        if (AnzahlMitarbeiter < 4)
            beitrag = AnzahlMitarbeiter * 250m;
        else
            beitrag = AnzahlMitarbeiter * 200m;
        return ErstelleDokument(AnzahlMitarbeiter, beitrag);
    }

    // TODO guten namen hierfür ausdenken
    private VersicherungsKonditionen ErstelleDokument(decimal berechnungbasis, decimal grundbeitrag)
    {
        var gesamtbeitrag = grundbeitrag;
        var webShopAufschlag = BerechneWebShopAufschlag(gesamtbeitrag);
        gesamtbeitrag += webShopAufschlag;
        var zusatzschutzAufschlagErrechnet = BerechneZusatzschutzAufschlag(gesamtbeitrag);
        gesamtbeitrag += zusatzschutzAufschlagErrechnet;
        var risikoAufschlag = BerechneRisikoAuschlag(gesamtbeitrag + zusatzschutzAufschlagErrechnet);
        gesamtbeitrag += risikoAufschlag;

        berechnungbasis = Math.Round(berechnungbasis, 2);
        grundbeitrag = Math.Round(grundbeitrag, 2);

        return new VersicherungsKonditionen(Guid.NewGuid(),
                            berechnungbasis,
                            grundbeitrag,
                            gesamtbeitrag,
                            webShopAufschlag,
                            zusatzschutzAufschlagErrechnet,
                            risikoAufschlag);
    }
}