using Application.Interfaces;
using Ardalis.Specification;
using Ardalis.Specification.EntityFrameworkCore;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Persistence.Data;

namespace Persistence.Repos;

public class EfReadonlyRepository<T>(ApplicationDbContext dbContext, IMapper mapper) : IQueryRepository<T>
    where T : BaseEntity
{
    private readonly ApplicationDbContext _dbContext = dbContext;
    private readonly IMapper _mapper = mapper;

    public async Task<T?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var keyValues = new object[] { id };
        return await _dbContext.Set<T>().FindAsync(keyValues, cancellationToken);
    }

    public async Task<IReadOnlyList<T>> ListAllAsync(CancellationToken cancellationToken = default)
    {
        return await _dbContext.Set<T>().ToListAsync(cancellationToken);
    }

    public async Task<IReadOnlyList<TRes>> ListAllAsync<TRes>(CancellationToken cancellationToken = default) where TRes : class
    {
        return  await _dbContext.Set<T>()
            .ProjectTo<TRes>(_mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken);
    }

    public async Task<List<T>> ListAsync(ISpecification<T> spec, CancellationToken cancellationToken = default)
    {
        var specificationResult = ApplySpecification(spec);
        return await specificationResult.ToListAsync(cancellationToken);
    }

    public async Task<IReadOnlyList<TRes>> ListAsync<TRes>(ISpecification<T> spec, CancellationToken cancellationToken = default)
    {
        var specificationResult = ApplySpecification(spec);
        return await specificationResult
            .ProjectTo<TRes>(_mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken);
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
        var specificationResult = ApplySpecification(spec);
        return await specificationResult.FirstAsync(cancellationToken);
    }

    public async Task<T?> FirstOrDefaultAsync(ISpecification<T> spec, CancellationToken cancellationToken = default)
    {
        var specificationResult = ApplySpecification(spec);
        return await specificationResult.FirstOrDefaultAsync(cancellationToken);
    }

    public Task<TRes?> FirstOrDefaultAsync<TRes>(ISpecification<T> spec, CancellationToken cancellationToken = default) where TRes : class
    {
        var specificationResult = ApplySpecification(spec);
        return specificationResult.ProjectTo<TRes>(_mapper.ConfigurationProvider).FirstOrDefaultAsync(cancellationToken);
    }
    
    private IQueryable<T?> ApplySpecification(ISpecification<T> spec)
    {
        var evaluator = new SpecificationEvaluator();
        return evaluator.GetQuery(_dbContext.Set<T>().AsQueryable(), spec);
    }
}