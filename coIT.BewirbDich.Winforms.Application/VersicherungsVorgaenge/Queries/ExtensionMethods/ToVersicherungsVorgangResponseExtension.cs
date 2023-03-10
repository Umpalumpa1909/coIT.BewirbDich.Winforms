using coIT.BewirbDich.Domain.Entities;

namespace coIT.BewirbDich.Application.VersicherungsVorgaenge.Queries.ExtensionMethods;

public static class ToVersicherungsVorgangResponseExtension
{
    public static VersicherungsVorgangResponse ToVersicherungsvorgangResponse(this VersicherungsVorgang versicherungsVorgang)
    {
        if (versicherungsVorgang.VorgangsStatus == Domain.Enums.VorgangsStatus.Versicherungsschein)
        {
            return new VersicherungsVorgangResponse(versicherungsVorgang.Id,
           versicherungsVorgang.VorgangsStatus,
           versicherungsVorgang.BerechungsParameter.Berechnungsart,
           versicherungsVorgang.BerechungsParameter.GetBerechnungsBasis(),
           versicherungsVorgang.BerechungsParameter.GetZusatzAufschlagProzent(),
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
            versicherungsVorgang.BerechungsParameter.Berechnungsart,
            versicherungsVorgang.BerechungsParameter.GetBerechnungsBasis(),
            versicherungsVorgang.BerechungsParameter.GetZusatzAufschlagProzent(),
            versicherungsVorgang.VersicherungsKonditionen.GrundBeitrag,
            versicherungsVorgang.VersicherungsKonditionen.RisikoAufschlag,
            versicherungsVorgang.VersicherungsKonditionen.ZusatzschutzAufschlag,
            versicherungsVorgang.VersicherungsKonditionen.WebShopAufschlag,
            versicherungsVorgang.VersicherungsKonditionen.GesamtBeitrag,
            null, null);
    }
}