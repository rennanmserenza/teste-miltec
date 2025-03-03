using System.Linq.Expressions;

namespace ProjetoAnunciosMilTec.Service.Interfaces;

public interface IBaseService<T> where T : class
{
    #region Obter por ID

    Task<T?> ObterPorIdAsync(long id, bool asNoTracking = true, params Expression<Func<T, object>>[] includes);

    #endregion Obter por ID

    #region Obter por expressão

    Task<T?> ObterAsync(Expression<Func<T, bool>> expression, bool asNoTracking = true, params Expression<Func<T, object>>[] includes);

    IQueryable<T> ObterVarios(Expression<Func<T, bool>> where, bool asNoTracking = true, params Expression<Func<T, object>>[] includes);

    Task<List<T>> ObterVariosAsync(Expression<Func<T, bool>> where, bool asNoTracking = true, params Expression<Func<T, object>>[] includes);

    #endregion Obter por expressão

    #region Obter todos

    IQueryable<T> ObterTodos(bool asNoTracking = true, params Expression<Func<T, object>>[] includes);

    Task<List<T>> ObterTodosAsync(bool asNoTracking = true, params Expression<Func<T, object>>[] includes);

    Task<(List<T> Registros, int TotalRegistros)> ObterPaginadoAsync(Expression<Func<T, bool>> where, int pagina, int tamanhoPagina, bool asNoTracking = true, params Expression<Func<T, object>>[] includes);

    #endregion Obter todos

    #region Executar comandos

    Task<T?> CriarAsync(T entidade);

    Task AtualizarAsync(T entidade);

    Task ExcluirAsync(T entidade);

    #endregion Executar comandos
}