using coIT.BewirbDich.Winforms.Application.Abstractions;
using coIT.BewirbDich.Winforms.Application.Abstractions.Messaging;
using coIT.BewirbDich.Winforms.Domain.DomainEvents;
using coIT.BewirbDich.Winforms.Domain.Repository;

namespace coIT.BewirbDich.Winforms.Application.VersicherungsVorgaenge.EventHandler;

internal sealed class AngebotAkzeptiertDomainEventHandler
    : IDomainEventHandler<AngebotAkzeptiertDomainEvent>
{
    private readonly IVersicherungsVorgangRepository versicherungsVorgangRepository;
    private readonly ICreditReformRequestService creditReformRequestService;
    private readonly IUnitOfWork unitOfWork;

    public AngebotAkzeptiertDomainEventHandler(IVersicherungsVorgangRepository versicherungsVorgangRepository,
        ICreditReformRequestService creditReformRequestService,
        IUnitOfWork unitOfWork)
    {
        this.versicherungsVorgangRepository = versicherungsVorgangRepository;
        this.creditReformRequestService = creditReformRequestService;
        this.unitOfWork = unitOfWork;
    }

    public async Task Handle(AngebotAkzeptiertDomainEvent notification,
        CancellationToken cancellationToken)
    {
        var versicherungsVorgang = await versicherungsVorgangRepository.GetByIdAsync(notification.versicherungsVorgangId,
            cancellationToken);
        if (versicherungsVorgang is null)
        {
            return;
        }
        var result = await creditReformRequestService.SendCreditReformRequestAsync(versicherungsVorgang, cancellationToken);
        if (result.IsSuccess)
        {
            versicherungsVorgang.AngebotAnnehmen(result.Value);
            await unitOfWork.SaveChangesAsync();
        }
    }
}