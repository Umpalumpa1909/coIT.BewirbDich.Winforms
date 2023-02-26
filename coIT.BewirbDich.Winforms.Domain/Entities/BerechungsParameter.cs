using coIT.BewirbDich.Domain.Enums;
using coIT.BewirbDich.Domain.Errors;
using coIT.BewirbDich.Domain.Primitives;
using coIT.BewirbDich.Domain.Shared;

namespace coIT.BewirbDich.Domain.Entities;

public sealed class BerechungsParameter : Entity
{
    public BerechungsParameter(Guid id, decimal versicherungssumme,
                               Zusatzschutz zusatzschutz,
                               bool hatWebshop,
                               int anzahlMitarbeiter,
                               Risiko risiko,
                               Berechnungsart berechnungsart)
        : base(id)
    {
        Versicherungssumme = versicherungssumme;
        Zusatzschutz = zusatzschutz;
        HatWebshop = hatWebshop;
        AnzahlMitarbeiter = anzahlMitarbeiter;
        Risiko = risiko;
        Berechnungsart = berechnungsart;
    }

    public int AnzahlMitarbeiter { get; set; }
    public Berechnungsart Berechnungsart { get; private set; }

    //Gibt es nur bei Unternehmen, die nach Umsatz abgerechnet werden
    public bool HatWebshop { get; private set; }

    public Risiko Risiko { get; private set; }
    public decimal Versicherungssumme { get; private set; }
    public Zusatzschutz Zusatzschutz { get; private set; }

    public Result<VersicherungsKonditionen> BerechneKonditionen()
    {
        var result = Validiere();
        if (result.IsFailure)
        {
            return Result.Failure<VersicherungsKonditionen>(result.Error);
        }
        return ErstelleVersicherungsKonditionen();
    }

    public decimal GetBerechnungsBasis()
    {
        if (Berechnungsart == Berechnungsart.AnzahlMitarbeiter)
        {
            return AnzahlMitarbeiter;
        }
        return Versicherungssumme;
    }

    public decimal GetZusatzAufschlagProzent()
    {
        decimal prozent = 0;
        switch (Zusatzschutz)
        {
            case Zusatzschutz.kein_Zusatzschutz:
                return 0;

            case Zusatzschutz.zehn_Prozent:
                prozent = 10;
                break;

            case Zusatzschutz.zwangzigprozent:
                prozent = 20;
                break;

            case Zusatzschutz.funfundzwangzigprozent:
                prozent = 25;
                break;

            default:
                break;
        }
        return prozent;
    }

    private decimal BerechneBeitrag()
    {
        switch (Berechnungsart)
        {
            case Berechnungsart.Umsatz:
                return 1.1m * (decimal)Math.Pow((double)Versicherungssumme, 0.25d);

            case Berechnungsart.Haushaltssumme:
                return 1.0m * (decimal)Math.Log10((double)Versicherungssumme) + 100m;

            case Berechnungsart.AnzahlMitarbeiter:
                return AnzahlMitarbeiter < 4 ? AnzahlMitarbeiter * 250m : AnzahlMitarbeiter * 200m;
        }
        return 0;
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

    private decimal BerechneWebShopAufschlag(decimal beitrag)
    {
        if (!HatWebshop)
            return 0m;
        return beitrag;
    }

    private decimal BerechneZusatzschutzAufschlag(decimal beitrag)
    {
        // Hier bin ich mir nicht sicher ob die Berechnung verändert werden soll als Aufgabe
        // habe es so verändert das der Prozentwert genutzt wird.
        //return beitrag * 1.0m + this.ZusatzschutzAufschlag / 100.0m;
        if (Zusatzschutz == Zusatzschutz.kein_Zusatzschutz)
        {
            return 0;
        }
        return beitrag * GetZusatzAufschlagProzent() / 100.0m;
    }

    private VersicherungsKonditionen ErstelleVersicherungsKonditionen()
    {
        var grundbeitrag = BerechneBeitrag();
        var gesamtbeitrag = grundbeitrag;
        var webShopAufschlag = BerechneWebShopAufschlag(gesamtbeitrag);
        gesamtbeitrag += webShopAufschlag;
        var zusatzschutzAufschlagErrechnet = BerechneZusatzschutzAufschlag(gesamtbeitrag);
        gesamtbeitrag += zusatzschutzAufschlagErrechnet;
        var risikoAufschlag = BerechneRisikoAuschlag(gesamtbeitrag + zusatzschutzAufschlagErrechnet);
        gesamtbeitrag += risikoAufschlag;
        grundbeitrag = Math.Round(grundbeitrag, 2);

        return new VersicherungsKonditionen(Guid.NewGuid(),
                            grundbeitrag,
                            gesamtbeitrag,
                            webShopAufschlag,
                            zusatzschutzAufschlagErrechnet,
                            risikoAufschlag);
    }

    private Result Validiere()
    {
        switch (Berechnungsart)
        {
            case Berechnungsart.Umsatz:
                break;

            case Berechnungsart.Haushaltssumme:
                if (Risiko != Risiko.Mittel)
                {
                    return Result.Failure(DomainErrors.BerechnungsParameter.ValidiereHaushaltssummeUngleichMittleresRisko);
                }
                if (HatWebshop)
                {
                    return Result.Failure(DomainErrors.BerechnungsParameter.WebShopIstFuerDieGewaehlteBerechnungsartUngueltig);
                }
                break;

            case Berechnungsart.AnzahlMitarbeiter:
                if (AnzahlMitarbeiter > 5)
                {
                    return Result.Failure(DomainErrors.BerechnungsParameter.ValidiereMehrAlsFuenfMitarbeiter);
                }
                if (HatWebshop)
                {
                    return Result.Failure(DomainErrors.BerechnungsParameter.WebShopIstFuerDieGewaehlteBerechnungsartUngueltig);
                }
                break;

            default:
                return Result.Failure(DomainErrors.BerechnungsParameter.ValidiereUnbekannteBerechnungsart);
        }
        return Result.Success();
    }
}