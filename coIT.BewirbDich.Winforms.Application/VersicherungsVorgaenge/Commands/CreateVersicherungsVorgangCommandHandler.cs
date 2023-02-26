using coIT.BewirbDich.Winforms.Application.Abstractions.Messaging;
using coIT.BewirbDich.Winforms.Domain.Entities;
using coIT.BewirbDich.Winforms.Domain.Repository;
using coIT.BewirbDich.Winforms.Domain.Shared;
using MediatR;

namespace coIT.BewirbDich.Winforms.Application.VersicherungsVorgaenge.Commands;

internal sealed class CreateVersicherungsVorgangCommandHandler : ICommandHandler<CreateVersicherungsVorgangCommand, Guid>
{
    private readonly IVersicherungsVorgangRepository versicherungsVorgangRepository;
    private readonly IUnitOfWork unitOfWork;

    public CreateVersicherungsVorgangCommandHandler(
        IVersicherungsVorgangRepository versicherungsVorgangRepository
        , IUnitOfWork unitOfWork)
    {
        this.versicherungsVorgangRepository = versicherungsVorgangRepository;
        this.unitOfWork = unitOfWork;
    }

    public async Task<Result<Guid>> Handle(CreateVersicherungsVorgangCommand request, CancellationToken cancellationToken)
    {
        var angebotsanfrage = new Angebotsanfrage(Guid.NewGuid(),
                                                 request.Versicherungssumme,
                                                 request.InkludiereZusatzschutz,
                                                 request.ZusatzschutzAufschlag,
                                                 request.HatWebshop,
                                                 request.AnzahlMitarbeiter,
                                                 request.Risiko,
                                                 request.Berechnungsart);

        var result = VersicherungsVorgang.Create(angebotsanfrage);
        if (result.IsSuccess)
        {
            versicherungsVorgangRepository.Add(result.Value);
            await unitOfWork.SaveChangesAsync(cancellationToken);
            return Result.Success(result.Value.Id);
        }
        return Result.Failure<Guid>(result.Error);
    }
}