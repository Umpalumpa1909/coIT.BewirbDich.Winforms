using coIT.BewirbDich.Domain.Entities;

namespace coIT.BewirbDich.Domain.Repository;

public interface IVersicherungsVorgangRepository
{
    void Add(VersicherungsVorgang versicherungsvorgang);

    Task DeleteById(Guid id, CancellationToken cancellationToken);

    Task<IList<VersicherungsVorgang>> GetBeendeteVersicherungsVorgaenge(CancellationToken cancellationToken, int ablfd = 0);

    Task<VersicherungsVorgang?> GetByIdAsync(Guid id, CancellationToken cancellationToken);

    Task<IList<VersicherungsVorgang>> GetNichtBeendeteVersicherungsVorgaenge(CancellationToken cancellationToken);
}