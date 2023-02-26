namespace coIT.BewirbDich.Domain.Repository;

public interface IUnitOfWork
{
    Task SaveChangesAsync(CancellationToken cancellationToken = default);
}