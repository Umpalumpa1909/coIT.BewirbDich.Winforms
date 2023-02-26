using coIT.BewirbDich.Winforms.Domain.Enums;
using FluentValidation;

namespace coIT.BewirbDich.Winforms.Domain;

public class CreateDocumentDTO
{
    public Berechnungsart Berechnungsart { get; set; }

    public int AnzahlMitarbeiter { get; set; } = 0;

    public Risiko Risiko { get; set; }

    public bool ZusatzschutzInkludieren { get; set; }
    public decimal ZusatzschutzAufschlag { get; set; }

    public decimal Versicherungssumme { get; set; }
    public bool hasWebShop { get; set; }
}

public class CreateDocumentDTOValidator : AbstractValidator<CreateDocumentDTO>
{
    public CreateDocumentDTOValidator()
    {
        RuleFor(x => x.Berechnungsart).IsInEnum();
        RuleFor(x => x.Risiko).IsInEnum();
        RuleFor(x => x.Versicherungssumme).GreaterThan(0m);
        RuleFor(x => x.ZusatzschutzAufschlag).GreaterThanOrEqualTo(0m);
    }
}