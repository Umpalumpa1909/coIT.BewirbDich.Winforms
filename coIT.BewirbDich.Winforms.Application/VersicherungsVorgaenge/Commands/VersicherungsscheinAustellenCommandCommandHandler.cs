using coIT.BewirbDich.Application.Abstractions.Messaging;
using coIT.BewirbDich.Domain.Repository;
using coIT.BewirbDich.Domain.Shared;

namespace coIT.BewirbDich.Application.VersicherungsVorgaenge.Commands;

internal sealed class VersicherungsscheinAustellenCommandCommandHandler : ICommandHandler<VersicherungsscheinAustellenCommand>
{
    private readonly IUnitOfWork unitOfWork;
    private readonly IVersicherungsVorgangRepository versicherungsVorgangRepository;

    public VersicherungsscheinAustellenCommandCommandHandler(
        IVersicherungsVorgangRepository versicherungsVorgangRepository
        , IUnitOfWork unitOfWork)
    {
        this.versicherungsVorgangRepository = versicherungsVorgangRepository;
        this.unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(VersicherungsscheinAustellenCommand request, CancellationToken cancellationToken)
    {
        var vorgang = await versicherungsVorgangRepository.GetByIdAsync(request.Id, cancellationToken);
        if (vorgang == null)
        {
            return Result.Failure(new Error("AngebotAkzeptierenCommandCommandHandler.Handle", $"Versicherungsvorgang {request.Id} existiert nicht"));
        }
        var result = vorgang.VersicherungsscheinAustellen();
        if (result.IsSuccess)
        {
            await unitOfWork.SaveChangesAsync(cancellationToken);
        }
        return result;
    }
}