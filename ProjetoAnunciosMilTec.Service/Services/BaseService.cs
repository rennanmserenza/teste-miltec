using Microsoft.EntityFrameworkCore;
using ProjetoAnunciosMilTec.Service.Interfaces;
using System.Linq.Expressions;

namespace ProjetoAnunciosMilTec.Service.Services;

public class BaseService<T>(DbContext context) : IBaseService<T> where T : class
{
    private readonly DbContext _context = context;
    private readonly DbSet<T> _dbSet = context.Set<T>();

    public async Task<T?> ObterPorIdAsync(long id, bool asNoTracking = true, params Expression<Func<T, object>>[] includes)
    {
        IQueryable<T> query = _dbSet;

        if (asNoTracking)
            query = query.AsNoTracking();

        foreach (var include in includes)
            query = query.Include(include);

        return await query.FirstOrDefaultAsync(e => EF.Property<int>(e, "Id") == id);
    }

    public async Task<T?> ObterAsync(Expression<Func<T, bool>> expression, bool asNoTracking = true, params Expression<Func<T, object>>[] includes)
    {
        IQueryable<T> query = _dbSet;

        if (asNoTracking)
            query = query.AsNoTracking();

        foreach (var include in includes)
            query = query.Include(include);

        return await query.FirstOrDefaultAsync(expression);
    }

    public IQueryable<T> ObterVarios(Expression<Func<T, bool>> where, bool asNoTracking = true, params Expression<Func<T, object>>[] includes)
    {
        var query = _dbSet.Where(where);

        if (asNoTracking)
            query = query.AsNoTracking();

        foreach (var include in includes)
            query = query.Include(include);

        return query;
    }

    public async Task<List<T>> ObterVariosAsync(Expression<Func<T, bool>> where, bool asNoTracking = true, params Expression<Func<T, object>>[] includes)
    {
        var query = ObterVarios(where, asNoTracking, includes);

        return await query.ToListAsync();
    }

    public IQueryable<T> ObterTodos(bool asNoTracking = true, params Expression<Func<T, object>>[] includes)
    {
        IQueryable<T> query = _dbSet;

        if (asNoTracking)
            query = query.AsNoTracking();

        foreach (var include in includes)
            query = query.Include(include);

        return query;
    }

    public async Task<List<T>> ObterTodosAsync(bool asNoTracking = true, params Expression<Func<T, object>>[] includes)
    {
        var query = ObterTodos(asNoTracking, includes);

        return await query.ToListAsync();
    }

    public async Task<(List<T> Registros, int TotalRegistros)> ObterPaginadoAsync(Expression<Func<T, bool>> where, int pagina, int tamanhoPagina, bool asNoTracking = true, params Expression<Func<T, object>>[] includes)
    {
        IQueryable<T> query = _dbSet.Where(where);

        if (asNoTracking)
            query = query.AsNoTracking();

        foreach (var include in includes)
            query = query.Include(include);

        int totalRegistros = await query.CountAsync();
        List<T> registros = await query.Skip((pagina - 1) * tamanhoPagina).Take(tamanhoPagina).ToListAsync();

        return (registros, totalRegistros);
    }

    public async Task<T?> CriarAsync(T entidade)
    {
        await _dbSet.AddAsync(entidade);
        await _context.SaveChangesAsync();
        return entidade;
    }

    public async Task AtualizarAsync(T entidade)
    {
        _dbSet.Update(entidade);
        await _context.SaveChangesAsync();
    }

    public async Task ExcluirAsync(T entidade)
    {
        _dbSet.Remove(entidade);
        await _context.SaveChangesAsync();
    }
}