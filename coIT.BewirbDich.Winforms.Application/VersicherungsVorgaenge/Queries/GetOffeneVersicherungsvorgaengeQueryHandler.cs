using coIT.BewirbDich.Application.Abstractions.Messaging;
using coIT.BewirbDich.Application.VersicherungsVorgaenge.Queries.ExtensionMethods;
using coIT.BewirbDich.Domain.Repository;
using coIT.BewirbDich.Domain.Shared;

namespace coIT.BewirbDich.Application.VersicherungsVorgaenge.Queries;

internal sealed partial class GetOffeneVersicherungsVorgaengeQueryHandler
    : IQueryHandler<GetOffeneVersicherungsVorgaengeQuery, VersicherungsVorgaengeResponse>
{
    private readonly IVersicherungsVorgangRepository versicherungsVorgangRepository;

    public GetOffeneVersicherungsVorgaengeQueryHandler(IVersicherungsVorgangRepository versicherungsVorgangRepository)
    {
        this.versicherungsVorgangRepository = versicherungsVorgangRepository;
    }

    public async Task<Result<VersicherungsVorgaengeResponse>> Handle(GetOffeneVersicherungsVorgaengeQuery request,
                                                             CancellationToken cancellationToken)
    {
        var result = await versicherungsVorgangRepository.GetNichtBeendeteVersicherungsVorgaenge(
          cancellationToken);
        if (result is null)
        {
            return new VersicherungsVorgaengeResponse(new());
        }
        var resultlist = result.Select(e => e.ToVersicherungsvorgangResponse());
        return new VersicherungsVorgaengeResponse(resultlist.ToList());
    }
}