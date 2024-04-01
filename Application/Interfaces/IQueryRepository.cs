using Ardalis.Specification;
using Domain.Entity;

namespace Application.Interfaces;

public interface IQueryRepository<T> where T : BaseEntity
{
    Task<T?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    Task<IReadOnlyList<T>> ListAllAsync(CancellationToken cancellationToken = default);
    Task<IReadOnlyList<TRes>> ListAllAsync<TRes>(CancellationToken cancellationToken = default) where TRes : class;
    Task<List<T>> ListAsync(ISpecification<T> spec, CancellationToken cancellationToken = default);

    Task<IReadOnlyList<TRes>> ListAsync<TRes>(ISpecification<T> spec,
        CancellationToken cancellationToken = default);

    Task<int> CountAsync(ISpecification<T> spec, CancellationToken cancellationToken = default);
    Task<bool> ExistAsync(ISpecification<T> spec, CancellationToken cancellationToken = default);
    Task<T?> FirstAsync(ISpecification<T> spec, CancellationToken cancellationToken = default);
    Task<T?> FirstOrDefaultAsync(ISpecification<T> spec, CancellationToken cancellationToken = default);
    Task<TRes?> FirstOrDefaultAsync<TRes>(ISpecification<T> spec, CancellationToken cancellationToken = default) where TRes : class;
}