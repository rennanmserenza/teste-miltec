using ProjetoAnunciosMilTec.Entity.Models;

namespace ProjetoAnunciosMilTec.Service.Interfaces;

public interface IAnuncioService<T> where T : Anuncio
{
    Task<IEnumerable<T>> ObterTodosAsync();

    Task<T?> ObterPorIdAsync(long id);

    Task CriarAsync(T anuncio);

    Task AtualizarAsync(T anuncio);

    Task ExcluirAsync(long id);
}