using coIT.BewirbDich.Application.Abstractions.Messaging;
using coIT.BewirbDich.Domain.Repository;
using coIT.BewirbDich.Domain.Shared;

namespace coIT.BewirbDich.Application.VersicherungsVorgaenge.Commands;

internal sealed class VersicherungsVorgangLoeschenCommandHandler : ICommandHandler<VersicherungsVorgangLoeschenCommand>
{
    private readonly IVersicherungsVorgangRepository versicherungsVorgangRepository;
    private readonly IUnitOfWork unitOfWork;

    public VersicherungsVorgangLoeschenCommandHandler(
        IVersicherungsVorgangRepository versicherungsVorgangRepository
        , IUnitOfWork unitOfWork)
    {
        this.versicherungsVorgangRepository = versicherungsVorgangRepository;
        this.unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(VersicherungsVorgangLoeschenCommand request, CancellationToken cancellationToken)
    {
        await versicherungsVorgangRepository.DeleteById(request.Id, cancellationToken);
        await unitOfWork.SaveChangesAsync(cancellationToken);
        return Result.Success();
    }
}