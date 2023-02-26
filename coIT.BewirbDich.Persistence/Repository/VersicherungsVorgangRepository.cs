using coIT.BewirbDich.Domain.Entities;
using coIT.BewirbDich.Domain.Enums;
using coIT.BewirbDich.Domain.Repository;
using Microsoft.EntityFrameworkCore;

namespace coIT.BewirbDich.Persistence.Repository;

public sealed class VersicherungsVorgangRepository : IVersicherungsVorgangRepository
{
    private readonly ApplicationDbContext dbContext;

    public VersicherungsVorgangRepository(ApplicationDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public void Add(VersicherungsVorgang versicherungsvorgang)
    {
        dbContext.Set<VersicherungsVorgang>().Add(versicherungsvorgang);
    }

    public async Task DeleteById(Guid id, CancellationToken cancellationToken)
    {
        var result = await GetByIdAsync(id, cancellationToken);
        if (result != null)
        {
            dbContext.Set<VersicherungsVorgang>().Remove(result);
        }
        return;
    }

    public async Task<VersicherungsVorgang?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        return await dbContext.Set<VersicherungsVorgang>()
             .Include(x => x.Angebotsanfrage)
             .Include(x => x.VersicherungsKonditionen)
             .Include(x => x.Versicherungsschein)
             .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
    }

    public async Task<IList<VersicherungsVorgang>> GetBeendeteVersicherungsVorgaenge
        (
         CancellationToken cancellationToken, int ablfd = 0)
    {
        return await dbContext.Set<VersicherungsVorgang>()
            .Include(x => x.Angebotsanfrage)
            .Include(x => x.VersicherungsKonditionen)
            .Include(x => x.Versicherungsschein)
            .Where(x => x.VorgangsStatus == VorgangsStatus.Lieferschein &&
             x.Versicherungsschein!.Versicherungsnummer! > ablfd)
            .ToListAsync(cancellationToken);
    }

    public async Task<IList<VersicherungsVorgang>> GetNichtBeendeteVersicherungsVorgaenge(CancellationToken cancellationToken)
    {
        return await dbContext.Set<VersicherungsVorgang>()
            .Include(x => x.Angebotsanfrage)
            .Include(x => x.VersicherungsKonditionen)
            .Where(x => x.VorgangsStatus != VorgangsStatus.Lieferschein)
            .ToListAsync(cancellationToken);
    }
}