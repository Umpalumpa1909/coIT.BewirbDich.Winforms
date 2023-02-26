using coIT.BewirbDich.Domain.Entities;
using coIT.BewirbDich.Domain.Enums;
using coIT.BewirbDich.Domain.Shared;

namespace coIT.BewirbDich.Application.Abstractions;

public interface ICreditReformRequestService
{
    Task<Result<CreditRating>> SendCreditReformRequestAsync(VersicherungsVorgang vorgang, CancellationToken cancellationToken = default);
}