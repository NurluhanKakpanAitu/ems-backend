using Application.Interfaces;
using Ardalis.Specification;
using Ardalis.Specification.EntityFrameworkCore;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Persistence.Data;

namespace Persistence.Repos;

public class EfAsyncRepository<T>(ApplicationDbContext dbContext, IMapper mapper) : IAsyncRepository<T>
    where T : BaseEntity
{
    private readonly IMapper _mapper = mapper;
    private readonly ApplicationDbContext _dbContext = dbContext;

    public async Task<T?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await _dbContext.Set<T>().FindAsync(new object[] { id }, cancellationToken);
    }

    public async Task<IReadOnlyList<T>> ListAllAsync(CancellationToken cancellationToken = default)
    {
        return await _dbContext.Set<T>().ToListAsync(cancellationToken);
    }

    public async Task<IReadOnlyList<TRes>> ListAllAsync<TRes>(CancellationToken cancellationToken = default) where TRes : class
    {
        return await _dbContext.Set<T>().ProjectTo<TRes>(_mapper.ConfigurationProvider).ToListAsync(cancellationToken);
    }

    public async Task<List<T>> ListAsync(ISpecification<T> spec, CancellationToken cancellationToken = default)
    {
        var specificationResult = ApplySpecification(spec);
        return await specificationResult.ToListAsync(cancellationToken);
    }

    public async Task<IReadOnlyList<TRes>> ListAsync<TRes>(ISpecification<T> spec, CancellationToken cancellationToken = default)
    {
        var specificationResult = ApplySpecification(spec);
        return await specificationResult.ProjectTo<TRes>(_mapper.ConfigurationProvider).ToListAsync(cancellationToken);
    }

    public async Task<int> CountAsync(ISpecification<T> spec, CancellationToken cancellationToken = default)
    {
        return await ApplySpecification(spec).CountAsync(cancellationToken);
    }

    public async Task<bool> ExistAsync(ISpecification<T> spec, CancellationToken cancellationToken = default)
    {
        return await ApplySpecification(spec).AnyAsync(cancellationToken);
    }

    public async Task<T?> FirstAsync(ISpecification<T> spec, CancellationToken cancellationToken = default)
    {
        return await _dbContext.Set<T>().FirstOrDefaultAsync(cancellationToken);
    }

    public async Task<T?> FirstOrDefaultAsync(ISpecification<T> spec, CancellationToken cancellationToken = default)
    {
        return await ApplySpecification(spec).FirstOrDefaultAsync(cancellationToken);
    }

    public async Task<TRes?> FirstOrDefaultAsync<TRes>(ISpecification<T> spec, CancellationToken cancellationToken = default) where TRes : class
    {
        return await _dbContext.Set<T>().ProjectTo<TRes>(_mapper.ConfigurationProvider).FirstOrDefaultAsync(cancellationToken);
    }

    public async Task<T> AddAsync(T entity, CancellationToken cancellationToken = default)
    {
        await _dbContext.Set<T>().AddAsync(entity, cancellationToken);
        await _dbContext.SaveChangesAsync(cancellationToken);
        return entity;
    }

    public async Task<T> AddNotTrackedAsync(T entity, CancellationToken cancellationToken = default)
    {
        await _dbContext.Set<T>().AddAsync(entity, cancellationToken);
        return entity;
    }

    public async Task AddRangeNotTrackedAsync(IEnumerable<T> entity, CancellationToken cancellationToken = default)
    {
        await _dbContext.Set<T>().AddRangeAsync(entity, cancellationToken);
    }

    public async Task AddRangeAsync(IEnumerable<T> entity, CancellationToken cancellationToken = default)
    {
        await _dbContext.Set<T>().AddRangeAsync(entity, cancellationToken);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task UpdateAsync(T entity, CancellationToken cancellationToken = default)
    {
        _dbContext.Set<T>().Update(entity);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task UpdateRangeAsync(IEnumerable<T> entity, CancellationToken cancellationToken = default)
    {
        _dbContext.Set<T>().UpdateRange(entity);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task AddOrUpdateAsync(T entity)
    {
        var entry = _dbContext.Entry(entity);
        switch (entry.State)
        {
            case EntityState.Detached:
                await AddAsync(entity);
                break;
            case EntityState.Modified:
                await UpdateAsync(entity);
                break;
            case EntityState.Added:
                await AddAsync(entity);
                break;
            default:
                throw new ArgumentOutOfRangeException();
        } 
    }

    public async Task DeleteAsync(T entity, CancellationToken cancellationToken = default)
    {
        _dbContext.Set<T>().Remove(entity);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task DeleteAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var entity = _dbContext.Set<T>().FirstOrDefault(x => x.Id == id);
        if (entity == null)
            return;
        _dbContext.Set<T>().Remove(entity);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task DeleteAsync(IEnumerable<T> entities, CancellationToken cancellationToken = default)
    {
        _dbContext.Set<T>().RemoveRange(entities);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }
    
    private IQueryable<T> ApplySpecification(ISpecification<T> spec)
    {
        var evaluator = new SpecificationEvaluator();
        return evaluator.GetQuery(_dbContext.Set<T>().AsQueryable(), spec);
    }
}