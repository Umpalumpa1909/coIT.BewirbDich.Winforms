using coIT.BewirbDich.Winforms.Domain.Primitives;

namespace coIT.BewirbDich.Winforms.Domain.Entities;

public sealed class VersicherungsKonditionen : Entity
{
    public VersicherungsKonditionen(Guid id,
                    decimal berechnungsbasis,
                    decimal grundBeitrag,
                    decimal gesamtBeitrag,
                    decimal webShopAufschlag,
                    decimal zusatzschutzAufschlag,
                    decimal risikoAufschlag)
        : base(id)
    {
        Berechnungsbasis = berechnungsbasis;
        GrundBeitrag = grundBeitrag;
        GesamtBeitrag = gesamtBeitrag;
        WebShopAufschlag = webShopAufschlag;
        ZusatzschutzAufschlag = zusatzschutzAufschlag;
        RisikoAufschlag = risikoAufschlag;
    }

    public decimal Berechnungsbasis { get; private set; }
    public decimal GrundBeitrag { get; private set; }
    public decimal WebShopAufschlag { get; private set; }
    public decimal ZusatzschutzAufschlag { get; private set; }
    public decimal RisikoAufschlag { get; private set; }
    public decimal GesamtBeitrag { get; private set; }
}