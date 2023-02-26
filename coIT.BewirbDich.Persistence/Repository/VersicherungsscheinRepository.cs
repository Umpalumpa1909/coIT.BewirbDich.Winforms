//using coIT.BewirbDich.Winforms.Domain.Entities;
//using coIT.BewirbDich.Winforms.Domain.Repository;
//using Microsoft.EntityFrameworkCore;

//namespace coIT.BewirbDich.Persistence.Repository;

//internal class VersicherungsscheinRepository : IVersicherungsscheinRepository
//{
//    private readonly ApplicationDbContext dbContext;

//    public VersicherungsscheinRepository(ApplicationDbContext dbContext)
//    {
//        this.dbContext = dbContext;
//    }

//    public async Task<int> GibNeueVersicherungsnummer(CancellationToken cancellationToken)
//    {
//        return await dbContext.Set<Versicherungsschein>().MaxAsync(e => e.Versicherungsnummer, cancellationToken) + 1;
//    }
//}