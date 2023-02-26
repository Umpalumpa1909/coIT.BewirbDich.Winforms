using coIT.BewirbDich.Application.Abstractions.Messaging;
using coIT.BewirbDich.Domain.Entities;
using coIT.BewirbDich.Domain.Repository;
using coIT.BewirbDich.Domain.Shared;

namespace coIT.BewirbDich.Application.VersicherungsVorgaenge.Commands;

internal sealed class CreateVersicherungsVorgangCommandHandler : ICommandHandler<CreateVersicherungsVorgangCommand, Guid>
{
    private readonly IUnitOfWork unitOfWork;
    private readonly IVersicherungsVorgangRepository versicherungsVorgangRepository;

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