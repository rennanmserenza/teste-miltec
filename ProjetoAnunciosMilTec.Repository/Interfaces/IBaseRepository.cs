using System.Linq.Expressions;

namespace ProjetoAnunciosMilTec.Repository.Interfaces;

public interface IBaseRepository<T> where T : class
{
    Task<T?> GetFirstOrDefaultAsync(Expression<Func<T, bool>> expression);

    Task<T?> GetFirstOrDefaultAsync<TProperty>(
        Expression<Func<T, bool>> expression,
        Expression<Func<T, TProperty>> include);

    IQueryable<T> Get(Expression<Func<T, bool>> where,
        bool asNoTracking = true,
        params Expression<Func<T, object>>[] includes);

    IQueryable<T> GetAll(bool asNoTracking = true,
        params Expression<Func<T, object>>[] includes);

    IQueryable<T> GetPaged(Expression<Func<T, bool>> where,
        int page, int pageSize, out int totalItems,
        params Expression<Func<T, object>>[] includes);

    Task<T?> AddAsync(T entity);

    Task UpdateAsync(T entity);

    Task DeleteAsync(T entity);

    Task SaveChangesAsync();
}