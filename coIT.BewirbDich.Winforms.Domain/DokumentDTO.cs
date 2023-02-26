using coIT.BewirbDich.Winforms.Domain.Enums;

namespace coIT.BewirbDich.Winforms.Domain;

public class DokumentDTO
{
    public Guid Id { get; set; }

    public VorgangsStatus Typ { get; set; }
    public Berechnungsart Berechnungsart { get; set; }

    /// <summary>
    /// Berechnungsart Umsatz => Jahresumsatz in Euro,
    /// Berechnungsart Haushaltssumme => Haushaltssumme in Euro,
    /// Berechnungsart AnzahlMitarbeiter => Ganzzahl
    /// </summary>
    public decimal Berechnungbasis { get; set; }

    public bool InkludiereZusatzschutz { get; set; }
    public decimal ZusatzschutzAufschlag { get; set; }

    //Gibt es nur bei Unternehmen, die nach Umsatz abgerechnet werden
    public bool HatWebshop { get; set; }

    public Risiko Risiko { get; set; }

    public decimal Beitrag { get; set; }

    public bool VersicherungsscheinAusgestellt { get; set; }
    public decimal Versicherungssumme { get; set; }
    public bool AngebotAngenommen { get; set; }
}