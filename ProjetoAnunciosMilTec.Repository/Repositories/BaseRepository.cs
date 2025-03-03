using Microsoft.EntityFrameworkCore;
using ProjetoAnunciosMilTec.Repository.Interfaces;
using System.Linq.Expressions;

namespace ProjetoAnunciosMilTec.Repository.Repositories;

public class BaseRepository<T> : IBaseRepository<T> where T : class
{
    private readonly DbContext _context;
    private readonly DbSet<T> _dbSet;

    public BaseRepository(DbContext context)
    {
        _context = context;
        _dbSet = context.Set<T>();
    }

    public async Task<T?> GetFirstOrDefaultAsync(Expression<Func<T, bool>> expression)
    {
        return await _dbSet.AsNoTracking().FirstOrDefaultAsync(expression);
    }

    public async Task<T?> GetFirstOrDefaultAsync<TProperty>(
        Expression<Func<T, bool>> expression,
        Expression<Func<T, TProperty>> include)
    {
        return await _dbSet.AsNoTracking().Include(include).FirstOrDefaultAsync(expression);
    }

    public IQueryable<T> Get(Expression<Func<T, bool>> where, bool asNoTracking = true, params Expression<Func<T, object>>[] includes)
    {
        IQueryable<T> query = asNoTracking ? _dbSet.AsNoTracking() : _dbSet;
        query = query.Where(where);

        foreach (var include in includes)
        {
            query = query.Include(include);
        }

        return query;
    }

    public IQueryable<T> GetAll(bool asNoTracking = true, params Expression<Func<T, object>>[] includes)
    {
        IQueryable<T> query = asNoTracking ? _dbSet.AsNoTracking() : _dbSet;

        foreach (var include in includes)
        {
            query = query.Include(include);
        }

        return query;
    }

    public IQueryable<T> GetPaged(Expression<Func<T, bool>> where, int page, int pageSize, out int totalItems, params Expression<Func<T, object>>[] includes)
    {
        IQueryable<T> query = _dbSet.AsNoTracking().Where(where);

        foreach (var include in includes)
        {
            query = query.Include(include);
        }

        totalItems = query.Count();
        return query.Skip((page - 1) * pageSize).Take(pageSize);
    }

    public async Task<T?> AddAsync(T entity)
    {
        var result = await _dbSet.AddAsync(entity);
        await _context.SaveChangesAsync();
        return result.Entity;
    }

    public async Task UpdateAsync(T entity)
    {
        _dbSet.Attach(entity);
        _context.Entry(entity).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(T entity)
    {
        if (entity == null) throw new ArgumentNullException(nameof(entity));

        _dbSet.Remove(entity);
        await _context.SaveChangesAsync();
    }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }
}