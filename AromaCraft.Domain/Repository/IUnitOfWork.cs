using System;

namespace AromaCraft.Domain.Repository;

public interface IUnitOfWork
{
    public Task SaveChangesAsync(CancellationToken cancellationToken = default);
}
