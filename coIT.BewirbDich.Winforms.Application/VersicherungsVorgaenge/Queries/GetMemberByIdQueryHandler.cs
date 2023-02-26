using coIT.BewirbDich.Winforms.Application.Abstractions.Messaging;
using coIT.BewirbDich.Winforms.Application.VersicherungsVorgaenge.Queries.ExtensionMethods;
using coIT.BewirbDich.Winforms.Domain.Repository;
using coIT.BewirbDich.Winforms.Domain.Shared;

namespace coIT.BewirbDich.Winforms.Application.VersicherungsVorgaenge.Queries;

internal sealed class VersicherungsvorgangByIdQueryHandler
    : IQueryHandler<GetVersicherungsvorgangByIdQuery, VersicherungsVorgangResponse>
{
    private readonly IVersicherungsVorgangRepository versicherungsVorgangRepository;

    public VersicherungsvorgangByIdQueryHandler(IVersicherungsVorgangRepository versicherungsVorgangRepository)
    {
        this.versicherungsVorgangRepository = versicherungsVorgangRepository;
    }

    public async Task<Result<VersicherungsVorgangResponse>> Handle(GetVersicherungsvorgangByIdQuery request,
                                                             CancellationToken cancellationToken)
    {
        var result = await versicherungsVorgangRepository.GetByIdAsync(
          request.VersicherungsVorgangId,
          cancellationToken);
        if (result is null)
        {
            return Result.Failure<VersicherungsVorgangResponse>(new Error(
                "VersicherungsVorgangRepository.NotFound",
                $"Versicherungsvorgang {request.VersicherungsVorgangId} ist unbekannt"));
        }

        return result.ToVersicherungsvorgangResponse();
    }
}