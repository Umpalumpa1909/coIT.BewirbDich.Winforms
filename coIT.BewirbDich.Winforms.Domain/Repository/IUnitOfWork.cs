namespace coIT.BewirbDich.Winforms.Domain.Repository;

public interface IUnitOfWork
{
    Task SaveChangesAsync(CancellationToken cancellationToken = default);
}