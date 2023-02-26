using coIT.BewirbDich.Winforms.Domain.Entities;

namespace coIT.BewirbDich.Winforms.Application.VersicherungsVorgaenge.Queries.ExtensionMethods;

public static class ToVersicherungsVorgangResponseExtension
{
    public static VersicherungsVorgangResponse ToVersicherungsvorgangResponse(this VersicherungsVorgang versicherungsVorgang)
    {
        if (versicherungsVorgang.VorgangsStatus == Domain.Enums.VorgangsStatus.Lieferschein)
        {
            return new VersicherungsVorgangResponse(versicherungsVorgang.Id,
           versicherungsVorgang.VorgangsStatus,
           versicherungsVorgang.Angebotsanfrage.Berechnungsart,
           versicherungsVorgang.Angebotsanfrage.Versicherungssumme,
           versicherungsVorgang.VersicherungsKonditionen.GrundBeitrag,
           versicherungsVorgang.VersicherungsKonditionen.RisikoAufschlag,
           versicherungsVorgang.VersicherungsKonditionen.ZusatzschutzAufschlag,
           versicherungsVorgang.VersicherungsKonditionen.WebShopAufschlag,
           versicherungsVorgang.VersicherungsKonditionen.GesamtBeitrag,
           versicherungsVorgang.Versicherungsschein!.ErstellungsDatum,
           versicherungsVorgang.Versicherungsschein!.Versicherungsnummer);
        }

        return new VersicherungsVorgangResponse(versicherungsVorgang.Id,
            versicherungsVorgang.VorgangsStatus,
            versicherungsVorgang.Angebotsanfrage.Berechnungsart,
            versicherungsVorgang.Angebotsanfrage.Versicherungssumme,
            versicherungsVorgang.VersicherungsKonditionen.GrundBeitrag,
            versicherungsVorgang.VersicherungsKonditionen.RisikoAufschlag,
            versicherungsVorgang.VersicherungsKonditionen.ZusatzschutzAufschlag,
            versicherungsVorgang.VersicherungsKonditionen.WebShopAufschlag,
            versicherungsVorgang.VersicherungsKonditionen.GesamtBeitrag,
           null, null);
    }
}