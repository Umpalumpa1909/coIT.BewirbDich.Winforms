using coIT.BewirbDich.Winforms.Application.Abstractions.Messaging;
using coIT.BewirbDich.Winforms.Domain.Entities;
using coIT.BewirbDich.Winforms.Domain.Repository;
using coIT.BewirbDich.Winforms.Domain.Shared;
using MediatR;

namespace coIT.BewirbDich.Winforms.Application.VersicherungsVorgaenge.Commands;

internal sealed class AngebotAkzeptierenCommandCommandHandler : ICommandHandler<AngebotAkzeptierenCommand>
{
    private readonly IVersicherungsVorgangRepository versicherungsVorgangRepository;
    private readonly IUnitOfWork unitOfWork;

    public AngebotAkzeptierenCommandCommandHandler(
        IVersicherungsVorgangRepository versicherungsVorgangRepository
        , IUnitOfWork unitOfWork)
    {
        this.versicherungsVorgangRepository = versicherungsVorgangRepository;
        this.unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(AngebotAkzeptierenCommand request, CancellationToken cancellationToken)
    {
        var vorgang = await versicherungsVorgangRepository.GetByIdAsync(request.Id, cancellationToken);
        if (vorgang == null)
        {
            return Result.Failure(new Error("AngebotAkzeptierenCommandCommandHandler.Handle", $"Versicherungsvorgang {request.Id} existiert nicht"));
        }
        var result = vorgang.BestellungAusloesen();
        await unitOfWork.SaveChangesAsync(cancellationToken);
        return result;
    }
}