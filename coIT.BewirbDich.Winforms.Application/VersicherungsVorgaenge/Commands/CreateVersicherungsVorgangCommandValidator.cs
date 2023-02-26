using FluentValidation;

namespace coIT.BewirbDich.Application.VersicherungsVorgaenge.Commands;

internal class CreateVersicherungsVorgangCommandValidator : AbstractValidator<CreateVersicherungsVorgangCommand>
{
    public CreateVersicherungsVorgangCommandValidator()
    {
        RuleFor(x => x.Versicherungssumme).NotNull().GreaterThanOrEqualTo(0);
        RuleFor(x => x.AnzahlMitarbeiter).NotNull().GreaterThanOrEqualTo(0);
        RuleFor(x => x.Zusatzschutz).NotNull().IsInEnum();
        RuleFor(x => x.Risiko).NotNull().IsInEnum();
        RuleFor(x => x.Berechnungsart).NotNull().IsInEnum();
        RuleFor(x => x.HatWebshop).NotNull();
    }
}