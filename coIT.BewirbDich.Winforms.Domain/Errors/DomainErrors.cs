using coIT.BewirbDich.Domain.Shared;

namespace coIT.BewirbDich.Domain.Errors;

internal static class DomainErrors
{
    public static class BerechnungsParameter
    {
        public static readonly Error ValidiereHaushaltssummeUngleichMittleresRisko = new Error("BerechungsParameter.Validiere",
                            "Versicherungsnehmer, die nach Haushaltssumme versichert werden (primär Vereine) stellen immer ein mittleres Risiko da");

        public static readonly Error ValidiereMehrAlsFuenfMitarbeiter = new Error("BerechungsParameter.Validiere",
                        "Versicherungsnehmer, die nach Anzahl Mitarbeiter abgerechnet werden und mehr als 5 Mitarbeiter haben, können kein Lösegeld absichern");

        public static readonly Error ValidiereUnbekannteBerechnungsart = new Error("BerechnungsParameter.Validiere",
                                      "Angebot kann nicht erstellt werden aufgrund unbekannter Berechnungsart");

        public static readonly Error WebShopIstFuerDieGewaehlteBerechnungsartUngueltig = new Error("BerechungsParameter.Validiere",
                            "WebShopIstFuerDieGewaehlteBerechnungsartUngueltig");
    }

    public static class VersicherungsVorgang
    {
        public static readonly Error UnbekanntesCreditRating = new Error("VersicherungsVorgang.AngebotAnnehmen",
                    $"unbekanntes CreditRating");

        public static readonly Error VersicherungsVorgangStatusUngleichAngebot =
                    new Error("VersicherungsVorgang.BestellungAusloesen", "Nur für Angebote kann eine Bestellung ausgelöst werden");

        public static readonly Error VersicherungsVorgangStatusUngleichAuftragsbestätigung = new Error("VersicherungsVorgang.VersicherungsscheinAustellen",
                 "nur für Versicherungsvorgänge mit Status Auftragsbestätigung kann ein Versicherungsschein ausgestellt werden");
    }
}