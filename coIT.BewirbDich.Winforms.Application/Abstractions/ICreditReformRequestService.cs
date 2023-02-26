using coIT.BewirbDich.Winforms.Domain.Entities;
using coIT.BewirbDich.Winforms.Domain.Enums;
using coIT.BewirbDich.Winforms.Domain.Shared;

namespace coIT.BewirbDich.Winforms.Application.Abstractions;

public interface ICreditReformRequestService
{
    Task<Result<CreditRating>> SendCreditReformRequestAsync(VersicherungsVorgang vorgang, CancellationToken cancellationToken = default);
}