using coIT.BewirbDich.Winforms.Domain.Entities;
using coIT.BewirbDich.Winforms.Domain.Enums;

namespace coIT.BewirbDich.Winforms.Domain.Repository;

public interface IVersicherungsVorgangRepository
{
    void Add(VersicherungsVorgang versicherungsvorgang);

    Task DeleteById(Guid id, CancellationToken cancellationToken);
    Task<IList<VersicherungsVorgang>> GetBeendeteVersicherungsVorgaenge(CancellationToken cancellationToken, int ablfd = 0);
    Task<VersicherungsVorgang?> GetByIdAsync(Guid id, CancellationToken cancellationToken);

    Task<IList<VersicherungsVorgang>> GetNichtBeendeteVersicherungsVorgaenge(CancellationToken cancellationToken);
}