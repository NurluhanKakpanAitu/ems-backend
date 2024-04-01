using Domain.Entity;

namespace Application.Interfaces;

public interface IAsyncRepository<T> : IQueryRepository<T> where T : BaseEntity
{
    Task<T> AddAsync(T entity, CancellationToken cancellationToken = default);
    Task<T> AddNotTrackedAsync(T entity, CancellationToken cancellationToken = default);
    Task AddRangeNotTrackedAsync(IEnumerable<T> entity, CancellationToken cancellationToken = default);
    Task AddRangeAsync(IEnumerable<T> entity, CancellationToken cancellationToken = default);
    Task UpdateAsync(T entity, CancellationToken cancellationToken = default);
    Task UpdateRangeAsync(IEnumerable<T> entity, CancellationToken cancellationToken = default);
    Task AddOrUpdateAsync(T entity);
    Task DeleteAsync(T entity, CancellationToken cancellationToken = default);
    Task DeleteAsync(Guid id, CancellationToken cancellationToken = default);
    Task DeleteAsync(IEnumerable<T> entities, CancellationToken cancellationToken = default);
}