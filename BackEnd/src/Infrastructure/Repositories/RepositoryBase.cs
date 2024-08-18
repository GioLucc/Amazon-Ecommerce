using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Ecommerce.Application.Persistence;
using Ecommerce.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Expressions;

namespace Ecommerce.Infrastructure.Persistence.Repostories;

// Generic for every model in Domain
public class RepositoryBase<T> : IAsyncRepository<T> where T : class
{

    //DbContextInstance (DependencyInjection)
    protected readonly EcommerceDbContext _dbContext;

    public RepositoryBase(EcommerceDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    /// <summary>
    /// sends the insertion to the database
    public async Task<T> AddAsync(T entity)
    {
        // Create an instance of the entity and add the new record
        _dbContext.Set<T>().Add(entity);
        await _dbContext.SaveChangesAsync();
        return entity;
    }


    // Stays in the memory of the application server
    // Eventually SaveChangeAsync adds it
    public void AddEntity(T entity)
    {
        _dbContext.Set<T>().Add(entity);

    }

    public void AddRange(List<T> entities)
    {
        _dbContext.Set<T>().AddRange(entities);
    }

    public async Task DeleteAsync(T entity)
    {
        _dbContext.Set<T>().Remove(entity);
        await _dbContext.SaveChangesAsync();
    }

    public void DeleteEntity(T entity)
    {
        _dbContext.Set<T>().Remove(entity);
    }

    public void DeleteRange(IReadOnlyList<T> entities)
    {
        _dbContext.Set<T>().RemoveRange(entities);
    }

    public async Task<IReadOnlyList<T>> GetAllAsync()
    {
        return await _dbContext.Set<T>().ToListAsync();
    }

    public async Task<IReadOnlyList<T>> GetAsync(Expression<Func<T, bool>> predicate)
    {
        return await _dbContext.Set<T>().Where(predicate).ToListAsync();
    }

    public async Task<IReadOnlyList<T>> GetAsync(Expression<Func<T, bool>>? predicate, Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy, string? includeString, bool disableTracking = true)
    {
        IQueryable<T> query = _dbContext.Set<T>();
        
        if(disableTracking) query = query.AsNoTracking();

        if(!string.IsNullOrWhiteSpace(includeString)) query = query.Include(includeString);

        if(predicate != null) query = query.Where(predicate);

        if(orderBy != null) 
            return await orderBy(query).ToListAsync();

        return await query.ToListAsync();
    }

    public async Task<IReadOnlyList<T>> GetAsync(Expression<Func<T, bool>>? predicate, Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null, List<Expression<Func<T, object>>>? includes = null, bool disableTracking = true)
    {
        IQueryable<T> query = _dbContext.Set<T>();
        
        if(disableTracking) query = query.AsNoTracking();

        if(includes != null) query = includes.Aggregate(query,(current,include) => current.Include(include));

        if(predicate != null) query = query.Where(predicate);

        if(orderBy != null) 
            return await orderBy(query).ToListAsync();

        return await query.ToListAsync();
    }

    public async Task<T> GetByIdAsync(int id)
    {
        return ( await _dbContext.Set<T>().FindAsync(id))!;
    }

    public async Task<T> GetEntityAsync(Expression<Func<T, bool>>? predicate, List<Expression<Func<T, object>>>? includes = null, bool disableTracking = true)
    {
        IQueryable<T> query = _dbContext.Set<T>();
        
        if(disableTracking) query = query.AsNoTracking();

        if(includes != null) query = includes.Aggregate(query,(current,include) => current.Include(include));

        if(predicate != null) query = query.Where(predicate);
        return (await query.FirstOrDefaultAsync())!;
    }

    public async Task<T> UpdateAsync(T entity)
    {
        _dbContext.Set<T>().Attach(entity);
        _dbContext.Entry(entity).State = EntityState.Modified;
        await _dbContext.SaveChangesAsync();
        return entity;
    }

    public void UpdateEntity(T entity)
    {
        _dbContext.Set<T>().Attach(entity);
        _dbContext.Entry(entity).State = EntityState.Modified;
    }
}