using coIT.BewirbDich.Winforms.Application.Abstractions;
using coIT.BewirbDich.Winforms.Domain.Entities;
using coIT.BewirbDich.Winforms.Domain.Enums;
using coIT.BewirbDich.Winforms.Domain.Shared;

namespace coIT.BewirbDich.Winforms.Infrastructure.Services;

internal class CreditReformRequestService : ICreditReformRequestService
{
    public async Task<Result<CreditRating>> SendCreditReformRequestAsync(VersicherungsVorgang vorgang, CancellationToken cancellationToken = default)
    {
        if (vorgang == null)
        {
            return Result.Failure<CreditRating>(new Error("CreditReformRequestService.SendCreditReformRequestAsync",
                "Dokument ist nicht vorhanden"));
        }
        var simulatedRequestTime = Random.Shared.Next(5000, 30000);
        await Task.Delay(simulatedRequestTime);
        if (int.IsEvenInteger(vorgang.GetHashCode()))
        {
            return Result.Success(CreditRating.high);
        }
        return Result.Success(CreditRating.low);
    }
}