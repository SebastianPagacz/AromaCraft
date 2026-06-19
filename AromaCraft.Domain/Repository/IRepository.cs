using System;

namespace AromaCraft.Domain.Repository;

public interface IRepository<T> where T : class
{
    public void Add(T item);
    public Task<T> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    public Task<List<T>> GetAsync(CancellationToken cancellationToken = default);
}
