using coIT.BewirbDich.Domain.Primitives;

namespace coIT.BewirbDich.Domain.Entities;

public sealed class VersicherungsKonditionen : Entity
{
    public VersicherungsKonditionen(Guid id,
                    decimal grundBeitrag,
                    decimal gesamtBeitrag,
                    decimal webShopAufschlag,
                    decimal zusatzschutzAufschlag,
                    decimal risikoAufschlag)

        : base(id)
    {
        GrundBeitrag = grundBeitrag;
        GesamtBeitrag = gesamtBeitrag;
        WebShopAufschlag = webShopAufschlag;
        ZusatzschutzAufschlag = zusatzschutzAufschlag;
        RisikoAufschlag = risikoAufschlag;
    }

    public decimal GesamtBeitrag { get; private set; }
    public decimal GrundBeitrag { get; private set; }
    public decimal RisikoAufschlag { get; private set; }
    public decimal WebShopAufschlag { get; private set; }
    public decimal ZusatzschutzAufschlag { get; private set; }
    public decimal ZusatzschutzAufschlagProzent { get; private set; }
}