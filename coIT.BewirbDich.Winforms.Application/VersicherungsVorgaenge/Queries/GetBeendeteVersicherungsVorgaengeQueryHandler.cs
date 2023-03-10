using coIT.BewirbDich.Application.Abstractions.Messaging;
using coIT.BewirbDich.Application.VersicherungsVorgaenge.Queries.ExtensionMethods;
using coIT.BewirbDich.Domain.Repository;
using coIT.BewirbDich.Domain.Shared;

namespace coIT.BewirbDich.Application.VersicherungsVorgaenge.Queries;

internal sealed partial class GetBeendeteVersicherungsVorgaengeQueryHandler
    : IQueryHandler<GetBeendeteVersicherungsVorgaengeQuery, VersicherungsVorgaengeResponse>
{
    private readonly IVersicherungsVorgangRepository versicherungsVorgangRepository;

    public GetBeendeteVersicherungsVorgaengeQueryHandler(IVersicherungsVorgangRepository versicherungsVorgangRepository)
    {
        this.versicherungsVorgangRepository = versicherungsVorgangRepository;
    }

    public async Task<Result<VersicherungsVorgaengeResponse>> Handle(GetBeendeteVersicherungsVorgaengeQuery request,
                                                             CancellationToken cancellationToken)
    {
        var result = await versicherungsVorgangRepository.GetBeendeteVersicherungsVorgaenge(cancellationToken,
            request.AbVersicherungsnummer);

        if (result is null)
        {
            return new VersicherungsVorgaengeResponse(new());
        }
        var resultlist = result.Select(e => e.ToVersicherungsvorgangResponse());
        return new VersicherungsVorgaengeResponse(resultlist.ToList());
    }
}