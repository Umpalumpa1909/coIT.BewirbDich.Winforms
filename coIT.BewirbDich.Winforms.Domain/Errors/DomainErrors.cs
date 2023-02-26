using coIT.BewirbDich.Winforms.Domain.Shared;

namespace coIT.BewirbDich.Winforms.Domain.Errors;

internal static class DomainErrors
{
    public static class Angebotsanfrage
    {
        public static readonly Error ErstelleDokumentUnbekannteBerechnungsart = new Error("Angebotsanfrage.ErstelleAngebot",
                      "Angebot kann nicht erstellt werden aufgrund unbekannter Berechnungsart");
    }
}